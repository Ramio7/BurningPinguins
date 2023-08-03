using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class CreateAccountWindowPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _createAccountButton;
    [SerializeField] private Button _backToMenuButton;

    public static Canvas Canvas { get; private set; }

    private void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
    }
}
