using UnityEngine;

public class Ball : MonoBehaviour, IBall
{
    public GameObject BallObject => throw new System.NotImplementedException();

    public Rigidbody Rigidbody => throw new System.NotImplementedException();
}
