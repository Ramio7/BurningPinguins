using Photon.Pun;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _reviveTimerDuration;

    private static ReviveTimer ReviveTimer;
    private static List<PlayerView> Players = new();

    private void OnEnable()
    {
        ReviveTimer = new(_reviveTimerDuration, RevivePlayer);
        StartTheGame();
    }

    private void OnDisable()
    {
        ReviveTimer = null;
        Players.Clear();
    }

    private async void StartTheGame()
    {
        await Task.Run(() => WaitAllPlayersToSpawnAsync());
        GiveTheBallToRandomPlayer();
    }

    private Task WaitAllPlayersToSpawnAsync()
    {
        while (Players.Count < PhotonNetwork.CurrentRoom.PlayerCount) return Task.Delay(1000);
        return Task.FromResult(0);
    }

    private void GiveTheBallToRandomPlayer()
    {
        if (Players.Count == 1)
        {
            PlayerModel.GiveBall(Players[0]);
            return;
        }
        var playerIndex = Random.Range(0, Players.Count);
        PlayerModel.GiveBall(Players[playerIndex]);
    }

    public static void SpawnPlayer(GameObject playerPrefab)
    {
        var newPlayer = InstantiatePlayerObject(playerPrefab);
        InitPlayer(newPlayer);
    }

    private static GameObject InstantiatePlayerObject(GameObject playerPrefab)
    {
        var spawnPoint = LevelPresenter.Instance.GetEmptySpawnPoint();
        var newPlayer = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
        return newPlayer;
    }

    private static void InitPlayer(GameObject newPlayer)
    {
        AddPLayerViewToList(newPlayer);
        InitPlayerPresenter(newPlayer);
    }

    private static void AddPLayerViewToList(GameObject newPlayer)
    {
        Players.Add(newPlayer.GetComponent<PlayerView>());
    }

    private static void InitPlayerPresenter(GameObject newPlayer)
    {
        newPlayer.GetComponent<CameraMover>().StartCameraFollowing();
        var playerPresenter = newPlayer.GetComponent<PlayerPresenter>();
        playerPresenter.OnPlayerShutDown += ShutDownPlayer;
    }

    private static void ShutDownPlayer(IPlayerView playerToShutDown)
    {
        DeinitPlayer(playerToShutDown);
        StartReviveCountdown(playerToShutDown);
    }

    private static void DeinitPlayer(IPlayerView playerToShutDown)
    {
        playerToShutDown.GameObject.GetComponent<CameraMover>().StopCameraFollowing();
        playerToShutDown.GameObject.SetActive(false);
    }

    private static void StartReviveCountdown(IPlayerView playerToShutDown)
    {
        ReviveTimer.Start(playerToShutDown);
    }

    private void RevivePlayer(IPlayerView playerToRevive)
    {
        MovePlayerToNewSpawnPoint(playerToRevive);
        ReinitPlayer(playerToRevive);
    }

    private static void MovePlayerToNewSpawnPoint(IPlayerView playerToRevive)
    {
        var spawnPoint = LevelPresenter.Instance.GetEmptySpawnPoint();
        playerToRevive.GameObject.transform.position = spawnPoint.position;
    }

    private static void ReinitPlayer(IPlayerView playerToRevive)
    {
        playerToRevive.GameObject.SetActive(true);
        playerToRevive.GameObject.GetComponent<CameraMover>().StartCameraFollowing();
    }
}
