using UnityEngine;

[RequireComponent(typeof(IPlayerView))]
public abstract class UserInput : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private GroundCollisionDetector _collisionDetector;

    protected PlayerView PlayerView { get => _playerView; }
    protected GroundCollisionDetector GroundCollisionDetector { get => _collisionDetector; }
    

    public void OnEnable()
    {
        GameEntryPoint.Instance.OnUpdateEvent += OnUpdate;
    }

    public void OnDisable()
    {
        GameEntryPoint.Instance.OnUpdateEvent -= OnUpdate;
    }

    protected void OnUpdate()
    {
        Throw();
        if (!GroundCollisionDetector.IsGrounded) return;
        Move();
        Sprint();
        Jump();
    }

    protected abstract void Move();
    protected abstract void Sprint();
    protected abstract void Jump();
    protected abstract void Throw();
    protected abstract void Rotate();
}
