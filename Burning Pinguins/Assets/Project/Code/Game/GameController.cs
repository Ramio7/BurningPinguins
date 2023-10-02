using Photon.Pun;
using Photon.Realtime;

public class GameController : MonoBehaviourPunCallbacks
{
    public static GameController Instance;

    public override void OnEnable()
    {
        Instance = this;
    }

    public override void OnDisable()
    {
        Instance = null;
    }

    public void SpawnPlayer(Player player)
    {
        //var newPlayer = (PlayerView)PhotonNetwork.Instantiate(_playerPrefab);
        //newPlayer.GetComponent<CameraMover>().StartCameraFollowing();                                     продумай спавн игрока
        //newPlayer.SetPlayerCharacteristics(PlayerDataContainer.Instance.GetPlayerCharacteristics());
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
