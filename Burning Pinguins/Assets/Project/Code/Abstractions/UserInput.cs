using UnityEngine;

public abstract class UserInput : MonoBehaviour
{
    [SerializeField] protected IPlayerController _playerController;

    protected ColliderContactController _contactController;

    protected Command _moveCommand;
    protected Command _strafeCommand;
    protected Command _jumpCommand;
    protected Command _throwCommand;

    public void OnEnable()
    {
        GameEntryPoint.Instance.OnUpdateEvent += OnUpdate;
        _contactController = new(_playerController.PlayerCollider);
    }

    public void OnDisable()
    {
        GameEntryPoint.Instance.OnUpdateEvent -= OnUpdate;
        _contactController.Dispose();
    }

    protected void OnUpdate()
    {
        Move();
        Strafe();
        Jump();
        Throw();
    }

    protected abstract void Move();
    protected abstract void Strafe();
    protected abstract void Jump();
    protected abstract void Throw();
}
