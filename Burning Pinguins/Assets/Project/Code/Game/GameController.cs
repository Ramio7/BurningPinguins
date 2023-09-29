using Photon.Pun;
using UnityEngine;

public class GameController : MonoBehaviourPunCallbacks
{
    [SerializeField] private PlayerView _playerPrefab;

    public static GameController Instance;

    public override void OnEnable()
    {
        Instance = this;
    }

    public override void OnDisable()
    {
        Instance = null;
    }

    public void SpawnPlayer()
    {
        Instantiate(_playerPrefab).GetComponent<CameraMover>().StartCameraFollowing();
    }

    public void RevivePlayer()
    {

    }

    public void ShutDownPlayer(PlayerView playerToShutDown)
    {
        playerToShutDown.GetComponent<CameraMover>().StopCameraFollowing();
        playerToShutDown.gameObject.SetActive(false);
    }
}
