using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Transform), typeof(Rigidbody))]
public class PlayerView : MonoBehaviour, IPlayerView
{
    [SerializeField] private PlayerGameStats _playerGameStats;

    public bool IsWithBall { get; private set; }
    public Transform Transform { get => gameObject.transform; }
    public Rigidbody Rigidbody { get => gameObject.GetComponent<Rigidbody>(); }
    public Collider Collider { get => gameObject.GetComponent<Collider>(); }
    public IBall Ball { get; set; }
    public IPlayerCharacter Stats { get => _playerGameStats; }
}
