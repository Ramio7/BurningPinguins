using UnityEngine;

[RequireComponent(typeof(IBallView))]
public class BallPresenter : MonoBehaviour
{
    private IBallView _ballView;

    public IBallView BallView { get => _ballView; private set => _ballView = value; }

    private void Awake()
    {
        BallView = GetComponent<BallView>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        BallModel.ReturnBall(BallView);
    }
}
