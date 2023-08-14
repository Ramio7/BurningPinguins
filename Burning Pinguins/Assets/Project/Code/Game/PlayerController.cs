using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Transform), typeof(Rigidbody))]
public class PlayerController : MonoBehaviour, IPlayerController
{
    [SerializeField] private IPlayerCharacter _playerGameStats;
    [SerializeField] private IBall _ball;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private Collider _playerCollider;

    public IPlayerCharacter Stats { get => _playerGameStats; }
    public IBall Ball { get => _ball; private set => _ball = value; }
    public bool IsWithBall { get; private set; }
    public Transform PlayerTransform { get => _playerTransform; }
    public Rigidbody PlayerRigidbody { get => _playerRigidbody; }
    public Collider PlayerCollider { get => _playerCollider; }
}
