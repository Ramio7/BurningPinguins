using Photon.Pun;
using UnityEngine;

public class BallView : MonoBehaviour, IBallView, IPunObservable
{
    [SerializeField] private Transform _startingPoint;
    [SerializeField] private PlayerPresenter _myPlayer;
    [SerializeField, Tooltip("Timer duration in seconds")] private float _timerDuration;
    [SerializeField] private float _ballSpeed;

    private Timer _timer;

    public MeshRenderer MeshRenderer { get => gameObject.GetComponent<MeshRenderer>(); }
    public Collider Collider { get => gameObject.GetComponent<Collider>(); }
    public Timer Timer { get => _timer; }
    public Transform StartingPoint { get => _startingPoint; set => _startingPoint = value; }
    public PlayerPresenter MyPlayer { get => _myPlayer; set => _myPlayer = value; }
    public bool IsThrown { get; set; }
    public GameObject This { get => gameObject; }
    public float BallSpeed { get => _ballSpeed; set => _ballSpeed = value; }

    private void Awake()
    {
        SetTimer();
    }

    private void OnEnable()
    {
        GameEntryPoint.Instance.OnFixedUpdateEvent += MoveBall;
    }

    private void OnDisable()
    {
        GameEntryPoint.Instance.OnFixedUpdateEvent -= MoveBall;
    }

    private void OnDestroy()
    {
        _timer.Dispose();
    }

    private void MoveBall()
    {
        if (!IsThrown) transform.position = StartingPoint.position;
        else BallModel.MoveBall(this, transform.forward);
    }

    public void SetTimer()
    {
        _timer = new(_timerDuration, MyPlayer.ShutDownPlayer);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) stream.SendNext(IsThrown);
        else IsThrown = (bool)stream.ReceiveNext();
    }
}
