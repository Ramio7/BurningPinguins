using UnityEngine;

public class UserKeyboardInput : UserInput
{
    protected override void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        var direction = new Vector3(xAxis, 0, yAxis);

        PlayerView.Rigidbody.velocity = PlayerView.Characteristics.PlayerSpeed * direction.normalized;
    }

    protected override void Sprint()
    {
        var stats = PlayerView.Characteristics;
        if (Input.GetKey(KeyCode.LeftShift)) stats.PlayerSpeed = stats.PlayerBaseSpeed * stats.SprintModifier;
        else if (!Input.GetKey(KeyCode.LeftShift)) stats.PlayerSpeed = stats.PlayerBaseSpeed;
        else return;
    }

    protected override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var playerJumpForce = PlayerView.Characteristics.PLayerJumpHeight * PlayerView.Rigidbody.mass * -Physics.gravity.y;
            PlayerView.Rigidbody.AddForce(playerJumpForce * PlayerView.transform.up, ForceMode.Impulse);
        }
    }

    protected override void Throw()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return;

        if (!(PlayerView.IsWithBall && !PlayerView.Ball.IsThrown)) return;

        var mouseHitPosition = CalculateMousePositionVector(PlayerView.Ball.GameObject);
        var ballDirection = mouseHitPosition - PlayerView.Ball.GameObject.transform.position;
        BallModel.ThrowBall(PlayerView.Ball, ballDirection);
    }

    protected override void Rotate()
    {
        var mouseHitPosition = CalculateMousePositionVector(PlayerView.GameObject);
        PlayerView.transform.LookAt(mouseHitPosition);
    }

    private Vector3 CalculateMousePositionVector(GameObject rotatingObject)
    {
        var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(mouseRay, out RaycastHit hitInfo);
        var mouseHitPosition = hitInfo.point;
        mouseHitPosition.y = rotatingObject.transform.position.y;
        return mouseHitPosition;
    }
}
