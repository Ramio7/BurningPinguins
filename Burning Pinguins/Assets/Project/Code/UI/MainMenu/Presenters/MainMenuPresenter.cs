using PlayFab;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class MainMenuPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _createAccountButton;
    [SerializeField] private Button _loginAccountButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _startGameButton;

    public static Canvas Canvas { get; private set; }

    public void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        SubscribeButtons();
        SetSwitchableButtonsActive(PlayFabClientAPI.IsClientLoggedIn());
    }

    public void OnDisable()
    {
        Canvas = null;
        UnsubscribeButtons();
    }

    public void SubscribeButtons()
    {
        _createAccountButton.onClick.AddListener(SwitchToCreateAccountWindow);
        _loginAccountButton.onClick.AddListener(SwitchToLoginAccountWindow);
        _settingsButton.onClick.AddListener(SwitchToSettingsWindow);
        _shopButton.onClick.AddListener(SwitchToShopWindow);
        _exitButton.onClick.AddListener(Application.Quit);
        _startGameButton.onClick.AddListener(PhotonService.Instance.ConnectLobby);
        _startGameButton.onClick.AddListener(SwitchToLobbyWindow);
    }

    public void UnsubscribeButtons()
    {
        _createAccountButton.onClick.RemoveListener(SwitchToCreateAccountWindow);
        _loginAccountButton.onClick.RemoveListener(SwitchToLoginAccountWindow);
        _settingsButton.onClick.RemoveListener(SwitchToSettingsWindow);
        _shopButton.onClick.RemoveListener(SwitchToShopWindow);
        _exitButton.onClick.RemoveListener(Application.Quit);
        if (PhotonService.Instance != null) _startGameButton.onClick.RemoveListener(PhotonService.Instance.ConnectLobby);
        _startGameButton.onClick.AddListener(SwitchToLobbyWindow);
    }

    private void SetSwitchableButtonsActive(bool isLoggedIn)
    {
        if (isLoggedIn) _loginAccountButton.gameObject.GetComponentInChildren<TMP_Text>().text = "Log in";
        else _loginAccountButton.gameObject.GetComponentInChildren<TMP_Text>().text = "Switch account";
    }

    private void SwitchToCreateAccountWindow()
    {
        Canvas.enabled = false;
        CreateAccountWindowPresenter.Canvas.enabled = true;
    }

    private void SwitchToLoginAccountWindow()
    {
        Canvas.enabled = false;
        LoginAccountWindowPresenter.Canvas.enabled = true;
    }

    private void SwitchToSettingsWindow()
    {
        Canvas.enabled = false;
        GameSettingsPresenter.Canvas.enabled = true;
    }

    private void SwitchToShopWindow()
    {
        Canvas.enabled = false;
        ShopPresenter.Canvas.enabled = true;
    }

    private void SwitchToLobbyWindow()
    {
        Canvas.enabled = false;
        LobbyPresenter.Canvas.enabled = true;
    }
}
