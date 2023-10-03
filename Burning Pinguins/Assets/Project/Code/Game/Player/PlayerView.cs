using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider), typeof(Transform), typeof(Rigidbody))]
public class PlayerView : MonoBehaviour, IPlayerView
{
    [Inject] private readonly IPlayerCharacter _playerGameCharacteristics;

    public bool IsWithBall { get; private set; }
    public Rigidbody Rigidbody { get => gameObject.GetComponent<Rigidbody>(); }
    public Collider Collider { get => gameObject.GetComponent<Collider>(); }
    public IBall Ball { get; set; }
    public IPlayerCharacter Characteristics { get => _playerGameCharacteristics; }
}
