using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class LoginAccountWindowPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _switchAccountButton;
    [SerializeField] private Button _backToMainMenuButton;

    [SerializeField] private TMP_Text _username;
    [SerializeField] private TMP_Text _password;

    public static Canvas Canvas { get; private set; }

    public void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        _switchAccountButton.onClick.AddListener(LoginAccount);
        _backToMainMenuButton.onClick.AddListener(SwitchToMainMenu);
    }

    public void OnDisable()
    {
        Canvas = null;
        _switchAccountButton.onClick.RemoveListener(LoginAccount);
        _backToMainMenuButton.onClick.RemoveListener(SwitchToMainMenu);
    }

    private void LoginAccount()
    {
        MainMenuEntryPoint.PlayFabService.ConnectViaPlayFab(_username.text, _password.text);
        SwitchToMainMenu();
    }

    private void SwitchToMainMenu()
    {
        Canvas.enabled = false;
        MainMenuPresenter.Canvas.enabled = true;
    }
}
