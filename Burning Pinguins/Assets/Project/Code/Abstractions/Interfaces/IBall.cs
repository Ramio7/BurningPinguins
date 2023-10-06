using UnityEngine;

public interface IBall
{
    public Rigidbody Rigidbody { get; }
    public MeshRenderer MeshRenderer { get; }
    public Collider Collider { get; }
    public Timer Timer { get; }
}
