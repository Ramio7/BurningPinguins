using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class LobbyPresenter : MonoBehaviourPunCallbacks, IUiWindow
{
    [SerializeField] private Button _createNewGameButton;
    [SerializeField] private Button _joinFriendButton;
    [SerializeField] private Button _backToMainMenuButton;

    public static Canvas Canvas { get; private set; }

    public override void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        SubscribeButtons();
    }

    public override void OnDisable()
    {
        Canvas = null;
        UnsubscribeButtons();
    }

    private void SubscribeButtons()
    {
        _createNewGameButton.onClick.AddListener(SwitchToCreateNewGameWindow);
        _joinFriendButton.onClick.AddListener(SwitchToGameChoiceWindow);
        _backToMainMenuButton.onClick.AddListener(SwitchToMainMenu);
    }

    private void UnsubscribeButtons()
    {
        _createNewGameButton.onClick.RemoveListener(SwitchToCreateNewGameWindow);
        _joinFriendButton.onClick.RemoveListener(SwitchToGameChoiceWindow);
        _backToMainMenuButton.onClick.RemoveListener(SwitchToMainMenu);
    }

    private void SwitchToCreateNewGameWindow()
    {

    }

    private void SwitchToGameChoiceWindow()
    {

    }

    private void SwitchToMainMenu()
    {
        Canvas.enabled = false;
        MainMenuPresenter.Canvas.enabled = true;
    }
}
