using Photon.Pun;
using UnityEngine;

public class LobbyPresenter : MonoBehaviourPunCallbacks, IUiWindow
{
    public static Canvas Canvas;

    public override void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
    }

    public override void OnDisable()
    {
        Canvas = null;
    }
}
