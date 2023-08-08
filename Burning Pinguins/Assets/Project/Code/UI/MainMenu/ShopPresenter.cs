using UnityEngine;

public class ShopPresenter : MonoBehaviour, IUiWindow
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
