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
        GameEntryPoint.Instance.OnFixedUpdateEvent += OnUpdate;
    }

    public void OnDisable()
    {
        GameEntryPoint.Instance.OnFixedUpdateEvent -= OnUpdate;
    }

    protected void OnUpdate()
    {
        Move();
        Sprint();
        Jump();
        Throw();
    }

    protected abstract void Move();
    protected abstract void Sprint();
    protected abstract void Jump();
    protected abstract void Throw();
}
