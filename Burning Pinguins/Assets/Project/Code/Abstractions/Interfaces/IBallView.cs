using UnityEngine;

public interface IBallView
{
    public MeshRenderer MeshRenderer { get; }
    public Collider Collider { get; }
    public Timer Timer { get; }
    public Transform StartingPoint { get; }
    public PlayerPresenter MyPlayer { get; }
    public bool IsThrown { get; set; }
    public Transform BallPosition { get; }
    public float BallSpeed { get; set; }
}
