using PlayFab;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class MainMenuPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _createAccountButton;
    [SerializeField] private Button _loginAccountButton;
    [SerializeField] private Button _switchAccountButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _startGameButton;

    [SerializeField] private CreateAccountWindowPresenter _createAccountCanvas;
    [SerializeField] private LoginAccountWindowPresenter _loginAccountCanvas;

    public static Canvas Canvas { get; private set; }

    private void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        SubscribeButtons();
        SetSwitchableButtonsActive(PlayFabClientAPI.IsClientLoggedIn());
    }

    private void OnDisable()
    {
        Canvas = null;
        UnsubscribeButtons();
    }

    private void SubscribeButtons()
    {
        _createAccountButton.onClick.AddListener(SwitchToCreateAccountWindow);
        _switchAccountButton.onClick.AddListener(SwitchToLoginAccountWindow);
        _loginAccountButton.onClick.AddListener(SwitchToLoginAccountWindow);
        _exitButton.onClick.AddListener(Application.Quit);
    }

    private void UnsubscribeButtons()
    {
        _createAccountButton.onClick.RemoveListener(SwitchToCreateAccountWindow);
        _switchAccountButton.onClick.RemoveListener(SwitchToLoginAccountWindow);
        _loginAccountButton.onClick.AddListener(SwitchToLoginAccountWindow);
        _exitButton.onClick.RemoveListener(Application.Quit);
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
}
