using UnityEngine;

public class JoinFriendWindowPresenter : MonoBehaviour, IUiWindow
{
    public static Canvas Canvas {  get; private set; }

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
        
    }

    public void UnsubscribeButtons()
    {
        
    }
}
