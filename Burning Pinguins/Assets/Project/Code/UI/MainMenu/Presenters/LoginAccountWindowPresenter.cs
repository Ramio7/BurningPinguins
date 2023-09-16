using PlayFab;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class LoginAccountWindowPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _loginAccountButton;
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private Button _loginAccountStatusBar;
    [SerializeField] private TMP_InputField _username;
    [SerializeField] private TMP_InputField _password;

    public static Canvas Canvas { get; private set; }

    public void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        ResetFields();
        SubscribeButtons();
        PlayFabService.Instance.AccountLoginCallback += ShowLoginResult;
    }

    public void OnDisable()
    {
        Canvas = null;
        ResetFields();
        UnsubscribeButtons();
        if (PlayFabService.Instance != null) PlayFabService.Instance.AccountLoginCallback -= ShowLoginResult;
    }

    public void SubscribeButtons()
    {
        _loginAccountButton.onClick.AddListener(LoginAccount);
        _backToMainMenuButton.onClick.AddListener(SwitchToMainMenu);
        _loginAccountStatusBar.onClick.AddListener(SwitchToMainMenu);
        _loginAccountStatusBar.onClick.AddListener(ResetFields);
    }

    public void UnsubscribeButtons()
    {
        _loginAccountButton.onClick.RemoveListener(LoginAccount);
        _backToMainMenuButton.onClick.RemoveListener(SwitchToMainMenu);
        _loginAccountStatusBar.onClick.RemoveListener(SwitchToMainMenu);
        _loginAccountStatusBar.onClick.RemoveListener(ResetFields);
    }

    private void LoginAccount() => PlayFabService.Instance.ConnectViaPlayFab(_username.text, _password.text);

    private void SwitchToMainMenu()
    {
        Canvas.enabled = false;
        MainMenuPresenter.Canvas.enabled = true;
    }

    private void ShowLoginResult(bool isLoginSucced)
    {
        SetFieldsOnLoginCheck(true);
        _loginAccountStatusBar.GetComponentInChildren<TMP_Text>().text = PlayFabService.Instance.AccountLoginMessage + "\n Click here to return to main menu";
    }

    private void ResetFields() => SetFieldsOnLoginCheck(false);

    private void SetFieldsOnLoginCheck(bool isAccountCreationCheck)
    {
        SetButtonActive(isAccountCreationCheck, _loginAccountStatusBar);
        SetButtonActive(!isAccountCreationCheck, _loginAccountButton);
        SetButtonActive(!isAccountCreationCheck, _backToMainMenuButton);
        SetInputFieldActive(!isAccountCreationCheck, _username);
        SetInputFieldActive(!isAccountCreationCheck, _password);
    }

    private void SetButtonActive(bool isActive, Button button) => button.gameObject.SetActive(isActive);

    private void SetInputFieldActive(bool isActive, TMP_InputField inputField) => inputField.gameObject.SetActive(isActive);
}
