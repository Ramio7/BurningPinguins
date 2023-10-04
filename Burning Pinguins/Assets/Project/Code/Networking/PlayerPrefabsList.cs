using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefabsList : MonoBehaviour, IPunObservable
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
        ClearPlayerPrefabs();
    }

    public void AddPlayerPrefab(int playerRoomId, PlayerView playerView) => _playerPrefabsDictionary.Add(playerRoomId, playerView);

    public void DeletePlayerPrefab(int playerRoomId) => _playerPrefabsDictionary.Remove(playerRoomId);

    public void ClearPlayerPrefabs() => _playerPrefabsDictionary.Clear();

    public PlayerView GetPlayerPrefab(int playerRoomId) => _playerPrefabsDictionary[playerRoomId];

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) stream.SendNext(_playerPrefabsDictionary);
        else _playerPrefabsDictionary = (Dictionary<int, PlayerView>)stream.ReceiveNext();
    }
}
