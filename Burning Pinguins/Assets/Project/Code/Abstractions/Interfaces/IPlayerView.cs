using UnityEngine;

public interface IPlayerView
{
    public IPlayerCharacter Characteristics { get; }
    public IBall Ball { get; set; }
    public bool IsWithBall { get; }
    public Transform Transform { get; }
    public Rigidbody Rigidbody { get; }
    public Collider Collider { get; }
}
