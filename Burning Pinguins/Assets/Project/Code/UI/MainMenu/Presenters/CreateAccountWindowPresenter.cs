using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class CreateAccountWindowPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _createAccountButton;
    [SerializeField] private Button _backToMenuButton;

    [SerializeField] private TMP_Text _usernameInputField;
    [SerializeField] private TMP_Text _passwordInputField;
    [SerializeField] private TMP_Text _emailInputField;

    public static Canvas Canvas { get; private set; }

    public void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        _createAccountButton.onClick.AddListener(CreateAccount);
        _backToMenuButton.onClick.AddListener(SwitchToMainMenu);
    }

    public void OnDisable()
    {
        Canvas = null;
        _createAccountButton.onClick.RemoveListener(CreateAccount);
        _backToMenuButton.onClick.RemoveListener(SwitchToMainMenu);
    }

    private void CreateAccount()
    {
        PlayFabService.Instance.CreatePlayFabAccount(_usernameInputField.text, _emailInputField.text, _passwordInputField.text);
        SwitchToMainMenu();
        PlayFabService.Instance.ConnectViaPlayFab(_usernameInputField.text, _passwordInputField.text);
    }

    private void SwitchToMainMenu()
    {
        Canvas.enabled = false;
        MainMenuPresenter.Canvas.enabled = true;
    }
}
