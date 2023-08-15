using UnityEngine;

public class UserKeyboardInput : UserInput
{
    protected override void Move()
    {
        float forwardSpeed;
        if (Input.GetKey(KeyCode.W)) forwardSpeed = 1;
        else if (Input.GetKey(KeyCode.S)) forwardSpeed = -1;
        else return;

        _playerController.PlayerRigidbody.AddForce(_playerController.Stats.PlayerSpeed * forwardSpeed * Time.deltaTime * _playerController.PlayerTransform.forward, ForceMode.VelocityChange);
    }

    protected override void Strafe()
    {
        float strafeSpeed;
        if (Input.GetKey(KeyCode.A)) strafeSpeed = -1;
        else if (Input.GetKey(KeyCode.D)) strafeSpeed = 1;
        else return;

        _playerController.PlayerRigidbody.AddForce(_playerController.Stats.PlayerSpeed * strafeSpeed * Time.deltaTime * _playerController.PlayerTransform.forward, ForceMode.VelocityChange);
    }

    protected override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _contactController.IsGrounded)
            _playerController.PlayerRigidbody.AddForce(_playerController.Stats.PLayerJumpForce * Time.deltaTime * _playerController.PlayerTransform.up, ForceMode.VelocityChange);
    }

    protected override void Throw()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _playerController.IsWithBall) 
            _playerController.Ball.Rigidbody.
                AddForce(_playerController.Stats.BallThrowForce * Time.deltaTime * _playerController.PlayerTransform.forward, ForceMode.VelocityChange);
    }
}
