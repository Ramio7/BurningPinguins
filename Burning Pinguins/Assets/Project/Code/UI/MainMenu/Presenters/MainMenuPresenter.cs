using PlayFab;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class MainMenuPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _createAccountButton;
    [SerializeField] private Button _loginAccountButton;
    [SerializeField] private Button _switchAccountButton;
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

    private void SubscribeButtons()
    {
        _createAccountButton.onClick.AddListener(SwitchToCreateAccountWindow);
        _switchAccountButton.onClick.AddListener(SwitchToLoginAccountWindow);
        _loginAccountButton.onClick.AddListener(SwitchToLoginAccountWindow);
        _settingsButton.onClick.AddListener(SwitchToSettingsWindow);
        _shopButton.onClick.AddListener(SwitchToShopWindow);
        _exitButton.onClick.AddListener(Application.Quit);
        _startGameButton.onClick.AddListener(MainMenuEntryPoint.PhotonService.JoinGame);
    }

    private void UnsubscribeButtons()
    {
        _createAccountButton.onClick.RemoveListener(SwitchToCreateAccountWindow);
        _switchAccountButton.onClick.RemoveListener(SwitchToLoginAccountWindow);
        _loginAccountButton.onClick.RemoveListener(SwitchToLoginAccountWindow);
        _settingsButton.onClick.RemoveListener(SwitchToSettingsWindow);
        _shopButton.onClick.RemoveListener(SwitchToShopWindow);
        _exitButton.onClick.RemoveListener(Application.Quit);
        _startGameButton.onClick.RemoveListener(MainMenuEntryPoint.PhotonService.JoinGame);
    }

    private void SetSwitchableButtonsActive(bool isLoggedIn)
    {
        _loginAccountButton.gameObject.SetActive(!isLoggedIn);
        _switchAccountButton.gameObject.SetActive(isLoggedIn);
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
}
