using UnityEngine;

public class GameSettingsPresenter : MonoBehaviour, IUiWindow
{
    public static Canvas Canvas;

    private void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
    }

    private void OnDisable()
    {
        Canvas = null;
    }
}
