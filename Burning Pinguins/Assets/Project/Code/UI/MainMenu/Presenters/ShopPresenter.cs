using UnityEngine;

public class ShopPresenter : MonoBehaviour, IUiWindow
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
