using Photon.Pun;
using UnityEngine;

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
    }

    private void SpawnPlayer(PlayerView playerPrefab)
    {
        var newPlayer = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        newPlayer.GetComponent<CameraMover>().StartCameraFollowing();
    }

    public void RevivePlayer(PlayerView playerToRevive)
    {
        playerToRevive.gameObject.SetActive(true);
        playerToRevive.GetComponent<CameraMover>().StopCameraFollowing();
    }

    public void ShutDownPlayer(PlayerView playerToShutDown)
    {
        playerToShutDown.GetComponent<CameraMover>().StopCameraFollowing();
        playerToShutDown.gameObject.SetActive(false);
    }
}
