using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JoinFriendWindowPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private TMP_InputField _roomnameInputField;
    [SerializeField] private Button _joinFriendButton;
    [SerializeField] private Button _joinFriendStatusButton;
    [SerializeField] private Button _backButton;

    public static Canvas Canvas {  get; private set; }

    public void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        SubscribeButtons();
    }

    public void OnDisable()
    {
        Canvas = null;
        UnsubscribeButtons();
    }

    public void SubscribeButtons()
    {
        _joinFriendButton.onClick.AddListener(JoinFriend);
        _joinFriendStatusButton.onClick.AddListener(SwitchToRoomWindow);
        _backButton.onClick.AddListener(SwitchToLobbyWindow);
    }

    public void UnsubscribeButtons()
    {
        _joinFriendButton.onClick.RemoveListener(JoinFriend);
        _joinFriendStatusButton.onClick.RemoveListener(SwitchToRoomWindow);
        _backButton.onClick.RemoveListener(SwitchToLobbyWindow);
    }

    private void JoinFriend() => PhotonNetwork.JoinRoom(_roomnameInputField.text);

    private void SwitchToRoomWindow()
    {
        Canvas.enabled = false;
        RoomWindowPresenter.Canvas.enabled = true;
    }

    private void SwitchToLobbyWindow()
    {
        Canvas.enabled = false;
        LobbyPresenter.Canvas.enabled = true;
    }
}
