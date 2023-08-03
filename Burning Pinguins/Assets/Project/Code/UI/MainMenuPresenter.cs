using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class MainMenuPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _createAccountButton;
    [SerializeField] private Button _loginAccountButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private CreateAccountWindowPresenter _createAccountCanvas;
    [SerializeField] private LoginAccountWindowPresenter _loginAccountCanvas;

    public static Canvas Canvas { get; private set; }

    private void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        SubscribeButtons();
    }

    private void OnDisable()
    {
        UnsubscribeButtons();
    }

    private void SubscribeButtons()
    {
        _createAccountButton.onClick.AddListener(SwitchToCreateAccountWindow);
        _loginAccountButton.onClick.AddListener(SwitchToLoginAccountWindow);
        _exitButton.onClick.AddListener(Application.Quit);
    }

    private void UnsubscribeButtons()
    {
        _createAccountButton.onClick.RemoveListener(SwitchToCreateAccountWindow);
        _loginAccountButton.onClick.RemoveListener(SwitchToLoginAccountWindow);
        _exitButton.onClick.RemoveListener(Application.Quit);
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
