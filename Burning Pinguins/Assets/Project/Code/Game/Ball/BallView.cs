using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallView : MonoBehaviour, IBallView, IPunObservable
{
    [SerializeField] private Transform _startingPoint;
    [SerializeField] private PlayerPresenter _myPlayer;
    [SerializeField, Tooltip("Timer duration in seconds")] private float _timerDuration;
    [SerializeField] private float _ballSpeed;
    [SerializeField] private bool _isThrown;

    private Timer _timer;

    public Timer Timer { get => _timer; }
    public Transform StartingPoint { get => _startingPoint; set => _startingPoint = value; }
    public PlayerPresenter MyPlayer { get => _myPlayer; set => _myPlayer = value; }
    public bool IsThrown { get => _isThrown; set => _isThrown = value; }
    public GameObject GameObject { get => gameObject; }
    public float BallSpeed { get => _ballSpeed; set => _ballSpeed = value; }
    public Rigidbody Rigidbody { get => gameObject.GetComponent<Rigidbody>(); }

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
        if (!IsThrown) transform.SetPositionAndRotation(StartingPoint.position, StartingPoint.rotation);
    }

    public void SetTimer(PlayerPresenter playerWithBall)
    {
        _timer?.Dispose();
        _timer = new(_timerDuration, playerWithBall.ShutDownPlayer);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) stream.SendNext(IsThrown);
        else IsThrown = (bool)stream.ReceiveNext();
    }
}
