using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Transform), typeof(Rigidbody))]
public class PlayerView : MonoBehaviour, IPlayerView
{
    private PlayerGameCharacteristics _playerGameCharacteristics;

    public bool IsWithBall { get; private set; }
    public Transform Transform { get => gameObject.transform; }
    public Rigidbody Rigidbody { get => gameObject.GetComponent<Rigidbody>(); }
    public Collider Collider { get => gameObject.GetComponent<Collider>(); }
    public IBall Ball { get; set; }
    public IPlayerCharacter Characteristics { get => _playerGameCharacteristics; private set => _playerGameCharacteristics = (PlayerGameCharacteristics)value; }

    public void SetPlayerCharacteristics(PlayerGameCharacteristics playerGameCharacteristics) => _playerGameCharacteristics = playerGameCharacteristics;
}
