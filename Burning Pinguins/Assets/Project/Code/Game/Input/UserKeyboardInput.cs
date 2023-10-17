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
        if (Input.GetKeyDown(KeyCode.Space)) PlayerView.Rigidbody.AddForce(PlayerView.Characteristics.PLayerJumpForce * PlayerView.transform.up, ForceMode.Impulse);
    }

    protected override void Throw()
    {
        if (!(Input.GetKeyDown(KeyCode.Mouse0) && PlayerView.IsWithBall)) return; 
        
        PlayerView.Ball.Rigidbody.AddForce(PlayerView.Characteristics.BallThrowForce * Time.deltaTime * PlayerView.transform.forward, ForceMode.Impulse);
        PlayerView.Ball.IsThrown = true;
    }

    protected override void Rotate()
    {
        var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(mouseRay, out RaycastHit hitInfo);
        var mouseHitPosition = hitInfo.point;
        mouseHitPosition.y = PlayerView.transform.position.y;
        PlayerView.transform.LookAt(mouseHitPosition);
    }
}
