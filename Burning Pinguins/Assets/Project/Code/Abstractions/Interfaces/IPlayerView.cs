using UnityEngine;

public interface IPlayerView
{
    public IPlayerCharacter Characteristics { get; }
    public IBall Ball { get; set; }
    public bool IsWithBall { get; }
    public Rigidbody Rigidbody { get; }
    public Collider Collider { get; }
}
