using Photon.Pun;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(LevelView))]
public class LevelPresenter : MonoBehaviour, IPunObservable
{
    [Inject] private readonly LevelModel _levelModel;
    private LevelView _levelView;

    public static LevelPresenter Instance;

    private void OnEnable()
    {
        Instance = this;
        _levelView = GetComponent<LevelView>();
    }

    public Transform GetEmptySpawnPoint() => _levelModel.GetEmptySpawnPointTransform(_levelView.SpawnPoints);

    public Transform GetBallSpawnPoint() => _levelView.BallStartingPoint;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            foreach (var spawnPoint in _levelView.SpawnPoints)
            {
                stream.SendNext(spawnPoint.IsOccupied);
            }
        }
        else
        {
            foreach (var spawnPoint in _levelView.SpawnPoints)
            {
                spawnPoint.IsOccupied = (bool)stream.ReceiveNext();
            }
        }
    }
}
