using UnityEngine;

public interface IPlayerCharacter
{
    public Transform PlayerTransform { get; }
    public Rigidbody PlayerRigidbody { get; }
    public float PlayerSpeed { get; }
    public PlayerController Controller { get; }
}
