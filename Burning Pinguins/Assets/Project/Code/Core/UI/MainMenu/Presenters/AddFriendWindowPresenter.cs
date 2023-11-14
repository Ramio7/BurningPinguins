using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddFriendWindowPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _addFriendButton;
    [SerializeField] private Button _addFriendStatusButton;
    [SerializeField] private TMP_InputField _friendNameInputField;

    public static Canvas Canvas {  get; private set; }

    public void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        SubscribeButtons();
        ResetFields();
    }

    public void OnDisable()
    {
        Canvas = null;
        UnsubscribeButtons();
        ResetFields();
    }

    public void SubscribeButtons()
    {
        _addFriendButton.onClick.AddListener(AddFriend);
        _addFriendStatusButton.onClick.AddListener(SwitchToMainMenu);
        _backButton.onClick.AddListener(SwitchToMainMenu);
    }

    public void UnsubscribeButtons()
    {
        _addFriendButton.onClick.RemoveListener(AddFriend);
        _addFriendStatusButton.onClick.AddListener(SwitchToMainMenu);
        _backButton.onClick.RemoveListener(SwitchToMainMenu);
    }

    private void AddFriend() => PlayFabService.Instance.AddFriend(_friendNameInputField.text);

    private void SwitchToMainMenu()
    {
        Canvas.enabled = false;
        MainMenuPresenter.Canvas.enabled = true;
    }

    private void ResetFields() => SetFieldsOnCreationCheck(false);

    private void SetFieldsOnCreationCheck(bool isAddFriendCheck)
    {
        SetButtonActive(isAddFriendCheck, _addFriendStatusButton);
        SetButtonActive(!isAddFriendCheck, _addFriendButton);
        SetButtonActive(!isAddFriendCheck, _backButton);
        SetInputFieldActive(!isAddFriendCheck, _friendNameInputField);
    }

    private void SetButtonActive(bool isActive, Button button) => button.gameObject.SetActive(isActive);

    private void SetInputFieldActive(bool isActive, TMP_InputField inputField) => inputField.gameObject.SetActive(isActive);
}
