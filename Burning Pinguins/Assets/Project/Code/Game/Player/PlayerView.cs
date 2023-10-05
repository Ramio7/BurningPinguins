using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Transform), typeof(Rigidbody))]
public class PlayerView : MonoBehaviour, IPlayerView, IPunObservable
{
    [SerializeField] private PlayerGameCharacteristics _playerGameCharacteristics;

    public bool IsWithBall { get; private set; }
    public Rigidbody Rigidbody { get => gameObject.GetComponent<Rigidbody>(); }
    public Collider Collider { get => gameObject.GetComponent<Collider>(); }
    public IBall Ball { get; set; }
    public IPlayerCharacter Characteristics { get => _playerGameCharacteristics; }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(IsWithBall);
        }
        else
        {
            IsWithBall = (bool)stream.ReceiveNext();
        }
    }
}
