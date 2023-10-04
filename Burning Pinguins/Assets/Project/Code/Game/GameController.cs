using Photon.Pun;

public class GameController : MonoBehaviourPunCallbacks
{
    public static GameController Instance;

    public override void OnEnable()
    {
        Instance = this;
        SpawnPlayers();
    }

    public override void OnDisable()
    {
        Instance = null;
    }

    private void SpawnPlayers()
    {
        foreach (var player in PhotonNetwork.CurrentRoom.Players) SpawnPlayer(PlayerPrefabsList.Instance.GetPlayerPrefab(player.Key));
        PhotonNetwork.Destroy(PlayerPrefabsList.Instance.gameObject);
    }

    private void SpawnPlayer(PlayerView playerPrefab)
    {
        var spawnPoint = LevelPresenter.Instance.GetEmptySpawnPoint();
        var newPlayer = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
        newPlayer.GetComponent<CameraMover>().StartCameraFollowing();
    }

    public void ShutDownPlayer(PlayerView playerToShutDown)
    {
        playerToShutDown.GetComponent<CameraMover>().StopCameraFollowing();
        playerToShutDown.gameObject.SetActive(false);
    }

    public void RevivePlayer(PlayerView playerToRevive)
    {
        playerToRevive.gameObject.SetActive(true);
        playerToRevive.GetComponent<CameraMover>().StartCameraFollowing();
    }
}
