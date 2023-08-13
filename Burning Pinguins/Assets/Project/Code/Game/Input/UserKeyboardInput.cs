using System.Collections.Generic;
using UnityEngine;

public class UserKeyboardInput : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private IPlayerCharacter _playerCharacter;

    private List<Command> commands = new();

    private Command _moveCommand;
    private Command _strafeCommand;
    private Command _jumpCommand;
    private Command _throwCommand;

    private void OnEnable()
    {
        _moveCommand = new(new() { KeyCode.W, KeyCode.S }, Move);
        _strafeCommand = new(new() { KeyCode.A, KeyCode.D }, Strafe);
        _jumpCommand = new(new() { KeyCode.Space, }, Jump);
    }

    private void OnDisable()
    {
        _moveCommand.Dispose();
        _strafeCommand.Dispose();
        _jumpCommand.Dispose();
    }

    private void Move()
    {
        float forwardSpeed;
        if (Input.GetKey(KeyCode.W)) forwardSpeed = 1;
        else if (Input.GetKey(KeyCode.S)) forwardSpeed = -1;
        else forwardSpeed = 0;

        _playerRigidbody.AddForce(_playerCharacter.PlayerSpeed * forwardSpeed * Time.deltaTime * _playerCharacter.PlayerTransform.forward, ForceMode.VelocityChange);
    }

    private void Strafe()
    {
        float strafeSpeed;
        if (Input.GetKey(KeyCode.A)) strafeSpeed = -1;
        else if (Input.GetKey(KeyCode.D)) strafeSpeed = 1;
        else strafeSpeed = 0;

        _playerRigidbody.AddForce(_playerCharacter.PlayerSpeed * strafeSpeed * Time.deltaTime * _playerCharacter.PlayerTransform.forward, ForceMode.VelocityChange);
    }

    private void Jump()
    {
        
    }
}
