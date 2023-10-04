using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListPresenter : MonoBehaviourPunCallbacks, IUiList
{

    [SerializeField] private Button _playerInfoContainerPrefab;

    [SerializeField] private Transform _playersUiContainer;

    private List<PlayerInfoContainer> _players = new();

    public Transform ListTransform { get => _playersUiContainer; private set => _playersUiContainer = value; }

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        _players.Clear();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        _players.Add(new(newPlayer, _playersUiContainer, _playerInfoContainerPrefab));
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        bool playerResult(PlayerInfoContainer result) { return result.PlayerInfo == otherPlayer; }
        var playerToDelete = _players.Find(playerResult);
        _players.Remove(playerToDelete);
        Destroy(playerToDelete.Container);
    }

    public override void OnJoinedRoom()
    {
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            _players.Add(new(player.Value, _playersUiContainer, _playerInfoContainerPrefab));
        }
    }

    public override void OnLeftRoom()
    {
        foreach (var player in _players) player.Dispose();
        _players.Clear();
    }
}
