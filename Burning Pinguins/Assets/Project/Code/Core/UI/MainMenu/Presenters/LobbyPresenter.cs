using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class LobbyPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _createNewGameButton;
    [SerializeField] private Button _joinFriendButton;
    [SerializeField] private Button _backToMainMenuButton;

    public static Canvas Canvas { get; private set; }

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
        _createNewGameButton.onClick.AddListener(SwitchToCreateGameWindow);
        _joinFriendButton.onClick.AddListener(SwitchToFriendChoiceWindow);
        _backToMainMenuButton.onClick.AddListener(SwitchToMainMenu);
    }

    public void UnsubscribeButtons()
    {
        _createNewGameButton.onClick.RemoveListener(SwitchToCreateGameWindow);
        _joinFriendButton.onClick.RemoveListener(SwitchToFriendChoiceWindow);
        _backToMainMenuButton.onClick.RemoveListener(SwitchToMainMenu);
    }

    private void SwitchToCreateGameWindow()
    {
        Canvas.enabled = false;
        CreateGameWindowPresenter.Canvas.enabled = true;
    }

    private void SwitchToFriendChoiceWindow()
    {
        Canvas.enabled = false;
        JoinFriendWindowPresenter.Canvas.enabled = true;
    }

    private void SwitchToMainMenu()
    {
        PhotonNetwork.LeaveLobby();
        Canvas.enabled = false;
        MainMenuPresenter.Canvas.enabled = true;
    }
}
