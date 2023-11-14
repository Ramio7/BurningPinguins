using UnityEngine;
using UnityEngine.UI;

public class ShopPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _backToMainMenuButton;

    public static Canvas Canvas;

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

    public void SubscribeButtons()
    {
        _backToMainMenuButton.onClick.AddListener(SwitchToMainMenu);
    }

    public void UnsubscribeButtons()
    {
        _backToMainMenuButton.onClick.RemoveListener(SwitchToMainMenu);
    }

    private void SwitchToMainMenu()
    {
        Canvas.enabled = false;
        MainMenuPresenter.Canvas.enabled = true;
    }
}
