using UnityEngine;

public class UserKeyboardInput : UserInput
{
    protected override void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        var direction = new Vector3(xAxis, 0, yAxis);

        PlayerView.Rigidbody.velocity = PlayerView.Stats.PlayerSpeed * direction.normalized;
    }

    protected override void Sprint()
    {
        var stats = PlayerView.Stats;
        if (Input.GetKey(KeyCode.LeftShift)) stats.PlayerSpeed = stats.PlayerBaseSpeed * stats.SprintModifier;
        else if (!Input.GetKey(KeyCode.LeftShift)) stats.PlayerSpeed = stats.PlayerBaseSpeed;
        else return;
    }

    protected override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundCollisionDetector.IsGrounded) PlayerView.Rigidbody.AddForce(PlayerView.Stats.PLayerJumpForce * 
            Time.deltaTime * PlayerView.Transform.up, ForceMode.Impulse);
    }

    protected override void Throw()
    {
        if (!(Input.GetKeyDown(KeyCode.Mouse0) && PlayerView.IsWithBall)) return; 
        
        PlayerView.Ball.Rigidbody.AddForce(PlayerView.Stats.BallThrowForce * Time.deltaTime * PlayerView.Transform.forward, ForceMode.Impulse);
    }
}
