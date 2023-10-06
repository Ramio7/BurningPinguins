using UnityEngine;

public class Ball : MonoBehaviour, IBall
{
    public Rigidbody Rigidbody => throw new System.NotImplementedException();

    public MeshRenderer MeshRenderer => throw new System.NotImplementedException();

    public Collider Collider => throw new System.NotImplementedException();

    public Timer Timer => throw new System.NotImplementedException();
}
