using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomWindowPresenter : MonoBehaviourPunCallbacks, IUiWindow
{
    [SerializeField] private Button _startTheGameButton;
    [SerializeField] private Button _leaveRoomButton;
    [SerializeField] private Button _roomnameButton;
    [SerializeField] private TMP_Text _roomname;

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
        _leaveRoomButton.onClick.AddListener(SwitchToLobbyWindow);
        _leaveRoomButton.onClick.AddListener(LeaveCurrentRoom);
        _roomnameButton.onClick.AddListener(CopyRoomnameToClipboard);
    }

    public void UnsubscribeButtons()
    {
        _startTheGameButton.onClick.RemoveListener(StartGame);
        _leaveRoomButton.onClick.RemoveListener(SwitchToLobbyWindow);
        _leaveRoomButton.onClick.RemoveListener(LeaveCurrentRoom);
        _roomnameButton.onClick.RemoveListener(CopyRoomnameToClipboard);
    }

    private void LeaveCurrentRoom() => PhotonNetwork.LeaveRoom(false);

    private void StartGame() => PhotonNetwork.LoadLevel(SceneList.SimpleGameMap.ToString());

    private void SwitchToLobbyWindow()
    {
        Canvas.enabled = false;
        LobbyPresenter.Canvas.enabled = true;
    }

    private void CopyRoomnameToClipboard() => GUIUtility.systemCopyBuffer = _roomname.text;
}
