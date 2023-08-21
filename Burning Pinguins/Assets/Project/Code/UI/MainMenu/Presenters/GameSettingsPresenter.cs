using UnityEngine;

public class GameSettingsPresenter : MonoBehaviour, IUiWindow
{
    public static Canvas Canvas;

    public void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
    }

    public void OnDisable()
    {
        Canvas = null;
    }
}
