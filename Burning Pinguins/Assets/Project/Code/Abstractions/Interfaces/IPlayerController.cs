using UnityEngine;

public interface IPlayerController
{
    public IPlayerCharacter Stats { get; }
    public IBall Ball { get; }
    public bool IsWithBall { get; }
    public Transform PlayerTransform { get; }
    public Rigidbody PlayerRigidbody { get; }
    public Collider PlayerCollider { get; }
}
