using UnityEngine;

public interface IBallView
{
    public Rigidbody Rigidbody { get; }
    public MeshRenderer MeshRenderer { get; }
    public Collider Collider { get; }
    public Timer Timer { get; }
    public Transform StartingPoint { get; }
    public PlayerPresenter MyPlayer { get; }
    public bool IsThrown { get; set; }
    public Vector3 BallPosition { get; set; }
}
