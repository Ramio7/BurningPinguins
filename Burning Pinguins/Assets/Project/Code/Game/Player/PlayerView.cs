using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Transform), typeof(Rigidbody))]
public class PlayerView : MonoBehaviour, IPlayerView, IPunObservable
{
    [SerializeField] private PlayerGameCharacteristics _playerGameCharacteristics;

    public bool IsWithBall { get; set; }
    public Rigidbody Rigidbody { get => gameObject.GetComponent<Rigidbody>(); }
    public Collider Collider { get => gameObject.GetComponent<Collider>(); }
    public IBallView Ball { get; set; }
    public IPlayerCharacter Characteristics { get => _playerGameCharacteristics; }

    public GameObject GameObject => gameObject;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) stream.SendNext(IsWithBall);
        else IsWithBall = (bool)stream.ReceiveNext();
    }
}
