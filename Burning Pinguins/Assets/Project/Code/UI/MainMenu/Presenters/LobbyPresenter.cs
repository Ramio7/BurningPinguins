using Photon.Pun;
using UnityEngine;

public class LobbyPresenter : MonoBehaviourPunCallbacks, IUiWindow
{
    public static Canvas Canvas { get; private set; }

    public override void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        SubscribeButtons();
    }

    public override void OnDisable()
    {
        Canvas = null;
        UnsubscribeButtons();
    }

    private void SubscribeButtons()
    {
        
    }

    private void UnsubscribeButtons()
    {
        
    }
}
