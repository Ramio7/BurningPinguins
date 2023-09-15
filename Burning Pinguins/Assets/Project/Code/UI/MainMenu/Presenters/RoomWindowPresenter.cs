using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomWindowPresenter : MonoBehaviourPunCallbacks, IUiWindow
{
    [SerializeField] private Button _startTheGameButton;
    [SerializeField] private Button _leaveRoomButton;
    [SerializeField] private TMP_Text _roomname;

    [SerializeField] private PlayerInfoContainer _playerInfoContainerPrefab;

    [SerializeField] private Transform _playersUiContainer;

    private List<PlayerInfoContainer> _players = new();

    public static Canvas Canvas;

    public override void OnEnable()
    {
        Canvas = GetComponent<Canvas>();

        _roomname.text = PhotonNetwork.CurrentRoom.Name;

        if (!PhotonNetwork.IsMasterClient) _startTheGameButton.interactable = false;
        else _startTheGameButton.interactable = true;

        SubscribeButtons();

        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        Canvas = null;

        UnsubscribeButtons();

        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void SubscribeButtons()
    {
        _startTheGameButton.onClick.AddListener(StartGame);
        _leaveRoomButton.onClick.AddListener(SwitchToMainMenu);
        _leaveRoomButton.onClick.AddListener(LeaveCurrentRoom);
    }

    public void UnsubscribeButtons()
    {
        _startTheGameButton.onClick.RemoveListener(StartGame);
        _leaveRoomButton.onClick.RemoveListener(SwitchToMainMenu);
        _leaveRoomButton.onClick.RemoveListener(LeaveCurrentRoom);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        var playerContainer = _playerInfoContainerPrefab.Init(newPlayer, _playersUiContainer);
        _players.Add(playerContainer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        bool playerResult(PlayerInfoContainer result) { return result.PlayerInfo == otherPlayer; }
        var playerToDelete = _players.Find(playerResult);
        _players.Remove(playerToDelete);
        Destroy(playerToDelete.gameObject);
    }

    private void LeaveCurrentRoom() => PhotonNetwork.LeaveRoom(false);

    private void StartGame() => PhotonNetwork.LoadLevel(SceneList.SimpleGameMap.ToString());

    private void SwitchToMainMenu()
    {
        Canvas.enabled = false;
        MainMenuPresenter.Canvas.enabled = true;
    }
}
