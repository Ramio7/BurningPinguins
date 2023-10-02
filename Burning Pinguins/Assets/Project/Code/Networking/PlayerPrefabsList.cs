using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefabsList : MonoBehaviour
{
    private Dictionary<int, PlayerView> _playerPrefabsDictionary = new();

    public static PlayerPrefabsList Instance;

    private void OnEnable()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void OnDestroy()
    {
        Instance = null;
        _playerPrefabsDictionary.Clear();
    }

    public void AddPlayerPrefab(int playerRoomId, PlayerView playerView) => _playerPrefabsDictionary.Add(playerRoomId, playerView);

    public void DeletePlayerPrefab(int playerRoomId) => _playerPrefabsDictionary.Remove(playerRoomId);
}
