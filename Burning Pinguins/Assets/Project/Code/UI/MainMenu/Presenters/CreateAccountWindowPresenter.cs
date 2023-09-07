using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class CreateAccountWindowPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _createAccountButton;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Button _createAccountStatusBar;
    [SerializeField] private TMP_InputField _usernameInputField;
    [SerializeField] private TMP_InputField _passwordInputField;
    [SerializeField] private TMP_InputField _emailInputField;

    public static Canvas Canvas { get; private set; }

    public void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        ResetFields();
        _createAccountButton.onClick.AddListener(CreateAccount);
        _backToMenuButton.onClick.AddListener(SwitchToMainMenu);
        _createAccountStatusBar.onClick.AddListener(SwitchToMainMenu);
        _createAccountStatusBar.onClick.AddListener(ResetFields);
        PlayFabService.Instance.AccountCreationCallback += LoginPlayFab;
        PlayFabService.Instance.AccountCreationCallback += ShowAccountCreationResult;
    }

    public void OnDisable()
    {
        Canvas = null;
        ResetFields();
        _createAccountButton.onClick.RemoveListener(CreateAccount);
        _backToMenuButton.onClick.RemoveListener(SwitchToMainMenu);
        _createAccountStatusBar.onClick.RemoveListener(SwitchToMainMenu);
        _createAccountStatusBar.onClick.RemoveListener(ResetFields);
        if (PlayFabService.Instance != null)
        {
            PlayFabService.Instance.AccountCreationCallback -= LoginPlayFab;
            PlayFabService.Instance.AccountCreationCallback -= ShowAccountCreationResult;
        }
    }

    private void CreateAccount() => PlayFabService.Instance.CreatePlayFabAccount(_usernameInputField.text, _emailInputField.text, _passwordInputField.text);

    private void LoginPlayFab(bool isAccountCreated)
    {
        if (isAccountCreated) PlayFabService.Instance.ConnectViaPlayFab(_usernameInputField.text, _passwordInputField.text);
        else return;
    }

    private void ShowAccountCreationResult(bool isAccountCreated)
    {
        SetFieldsOnCreationCheck(true);
        _createAccountStatusBar.GetComponentInChildren<TMP_Text>().text = PlayFabService.Instance.AccountCreationMessage + "\n Click here to return to main menu";
    }

    private void SwitchToMainMenu()
    {
        Canvas.enabled = false;
        MainMenuPresenter.Canvas.enabled = true;
    }

    private void ResetFields() => SetFieldsOnCreationCheck(false);

    private void SetFieldsOnCreationCheck(bool isAccountCreationCheck)
    {
        SetButtonActive(isAccountCreationCheck, _createAccountStatusBar);
        SetButtonActive(!isAccountCreationCheck, _backToMenuButton);
        SetButtonActive(!isAccountCreationCheck, _createAccountButton);
        SetInputFieldActive(!isAccountCreationCheck, _emailInputField);
        SetInputFieldActive(!isAccountCreationCheck, _passwordInputField);
        SetInputFieldActive(!isAccountCreationCheck, _usernameInputField);
    }

    private void SetButtonActive(bool isActive, Button button) => button.gameObject.SetActive(isActive);

    private void SetInputFieldActive(bool isActive, TMP_InputField inputField) => inputField.gameObject.SetActive(isActive);
}
