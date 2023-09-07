using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateGameWindowPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private TMP_InputField _gameNameInputField;
    [SerializeField] private Toggle _privateGameToggle;
    [SerializeField] private Button _createGameButton;
    [SerializeField] private Button _backButton;
    
    public void OnDisable()
    {
        
    }

    public void OnEnable()
    {
        
    }
}
