using UnityEngine;

public interface IPlayerView
{
    public IPlayerCharacter Characteristics { get; }
    public IBallView Ball { get; set; }
    public bool IsWithBall { get; set; }
    public Rigidbody Rigidbody { get; }
    public Collider Collider { get; }
    public GameObject GameObject { get; }
}
