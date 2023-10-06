using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _reviveTimerDuration;

    public static GameController Instance;
    private static ReviveTimer ReviveTimer;
    private static List<PlayerView> Players = new();

    private void OnEnable()
    {
        Instance = this;
        ReviveTimer = new(_reviveTimerDuration, RevivePlayer);
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public static void SpawnPlayer(PlayerView playerPrefab)
    {
        GameObject newPlayer = InstantiatePlayerObject(playerPrefab);
        InitPlayer(newPlayer);
    }

    private static GameObject InstantiatePlayerObject(PlayerView playerPrefab)
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
