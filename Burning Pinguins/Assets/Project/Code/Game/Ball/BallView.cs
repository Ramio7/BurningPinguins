using Photon.Pun;
using UnityEngine;

public class BallView : MonoBehaviour, IBallView, IPunObservable
{
    [SerializeField] private Transform _startingPoint;
    [SerializeField] private PlayerPresenter _myPlayer;
    [SerializeField] private float _timerDuration;

    private Timer _timer;

    public Rigidbody Rigidbody { get => gameObject.GetComponent<Rigidbody>(); }
    public MeshRenderer MeshRenderer { get => gameObject.GetComponent<MeshRenderer>(); }
    public Collider Collider { get => gameObject.GetComponent<Collider>(); }
    public Timer Timer { get => _timer; }
    public Transform StartingPoint { get => _startingPoint; }
    public PlayerPresenter MyPlayer { get => _myPlayer; }
    public bool IsThrown { get; set; }
    public Vector3 BallPosition { get => gameObject.transform.position; set => gameObject.transform.position = value; }

    private void Awake() => SetTimer();

    private void SetTimer()
    {
        _timer = new(_timerDuration, MyPlayer.ShutDownPlayer);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) stream.SendNext(IsThrown);
        else IsThrown = (bool)stream.ReceiveNext();
    }
}
