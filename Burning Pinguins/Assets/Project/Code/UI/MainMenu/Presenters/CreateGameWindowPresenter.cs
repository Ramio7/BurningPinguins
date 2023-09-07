using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateGameWindowPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private TMP_InputField _gameNameInputField;
    [SerializeField] private Toggle _privateGameToggle;
    [SerializeField] private Button _createGameButton;
    [SerializeField] private Button _backButton;

    public static Canvas Canvas;

    public void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        SubscribeButtons();
    }

    public void OnDisable()
    {
        Canvas = null;
        SubscribeButtons();
    }

    public void SubscribeButtons()
    {
        _createGameButton.onClick.AddListener(CreateRoom);
        _backButton.onClick.AddListener(SwitchToLobbyWindow);
    }

    public void UnsubscribeButtons()
    {
        _createGameButton.onClick.RemoveListener(CreateRoom);
        _backButton.onClick.RemoveListener(SwitchToLobbyWindow);
    }

    private void CreateRoom()
    {
        PhotonNetwork.CreateRoom(_gameNameInputField.text, new()
        {
            IsVisible = _privateGameToggle.isOn,
        });
        SwitchToRoomWindow();
    }

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
