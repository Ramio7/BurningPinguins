using Photon.Pun;
using UnityEngine;

public class GameController : MonoBehaviourPunCallbacks
{
    [SerializeField] private PlayerView _playerPrefab;

    private PlayerView _playerView;

    public override void OnEnable()
    {
        _playerView = Instantiate(_playerPrefab);
        _playerView.GetComponent<CameraMover>().StartCameraFollowing();
    }
}
