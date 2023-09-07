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

    private void SubscribeButtons()
    {
        _createNewGameButton.onClick.AddListener(SwitchToCreateGameWindow);
        _joinFriendButton.onClick.AddListener(SwitchToFriendChoiceWindow);
        _backToMainMenuButton.onClick.AddListener(SwitchToMainMenu);
    }

    private void UnsubscribeButtons()
    {
        _createNewGameButton.onClick.RemoveListener(SwitchToCreateGameWindow);
        _joinFriendButton.onClick.RemoveListener(SwitchToFriendChoiceWindow);
        _backToMainMenuButton.onClick.RemoveListener(SwitchToMainMenu);
    }

    private void SwitchToCreateGameWindow()
    {

    }

    private void SwitchToFriendChoiceWindow()
    {

    }

    private void SwitchToMainMenu()
    {
        Canvas.enabled = false;
        MainMenuPresenter.Canvas.enabled = true;
    }
}
