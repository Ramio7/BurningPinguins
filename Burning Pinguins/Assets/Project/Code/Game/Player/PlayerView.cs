using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Transform), typeof(Rigidbody))]
public class PlayerView : MonoBehaviour, IPlayerView, IPunObservable
{
    [SerializeField] private PlayerGameCharacteristics _playerGameCharacteristics;
    [SerializeField] private BallView _ball;

    public bool IsWithBall { get; set; }
    public Rigidbody Rigidbody { get => gameObject.GetComponent<Rigidbody>(); }
    public Collider Collider { get => gameObject.GetComponent<Collider>(); }
    public IBallView Ball { get => _ball; private set => _ball = (BallView)value; }
    public IPlayerCharacter Characteristics { get => _playerGameCharacteristics; }

    public GameObject GameObject => gameObject;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) stream.SendNext(IsWithBall);
        else IsWithBall = (bool)stream.ReceiveNext();
    }
}
