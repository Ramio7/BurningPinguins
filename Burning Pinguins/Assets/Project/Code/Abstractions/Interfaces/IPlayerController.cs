using UnityEngine;

public interface IPlayerController
{
    public IPlayerCharacter Stats { get; }
    public IBall Ball { get; }
    public bool IsWithBall { get; }
    public Transform Transform { get; }
    public Rigidbody Rigidbody { get; }
    public Collider Collider { get; }
}
