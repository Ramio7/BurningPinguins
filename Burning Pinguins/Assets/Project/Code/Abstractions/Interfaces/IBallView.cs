using UnityEngine;

public interface IBallView
{
    public Rigidbody Rigidbody { get; }
    public Timer Timer { get; }
    public Transform StartingPoint { get; set; }
    public PlayerPresenter MyPlayer { get; set; }
    public bool IsThrown { get; set; }
    public GameObject GameObject { get; }
    public float BallSpeed { get; set; }
    public void SetTimer(PlayerPresenter playerWithBall);
}
