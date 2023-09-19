using UnityEngine;

public class UserKeyboardInput : UserInput
{
    protected override void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        var direction = new Vector2(xAxis, yAxis);

        PlayerController.Rigidbody.AddForce(PlayerController.Stats.PlayerSpeed * Time.deltaTime * direction, ForceMode.VelocityChange);
    }

    protected override void Sprint()
    {
        var stats = PlayerController.Stats;
        if (Input.GetKey(KeyCode.LeftShift)) stats.PlayerSpeed = stats.PlayerBaseSpped * stats.SprintModifier;
        else if (!Input.GetKey(KeyCode.LeftShift)) stats.PlayerSpeed = stats.PlayerBaseSpped;
        else return;
    }

    protected override void Jump()
    {
        if (!(Input.GetKeyDown(KeyCode.Space) && ContactController.IsGrounded)) return;
        
        PlayerController.Rigidbody.AddForce(PlayerController.Stats.PLayerJumpForce * Time.deltaTime * PlayerController.Transform.up, ForceMode.Impulse);
    }

    protected override void Throw()
    {
        if (!(Input.GetKeyDown(KeyCode.Mouse0) && PlayerController.IsWithBall)) return; 
        
        PlayerController.Ball.Rigidbody.AddForce(PlayerController.Stats.BallThrowForce * Time.deltaTime * PlayerController.Transform.forward, ForceMode.VelocityChange);
    }
}
