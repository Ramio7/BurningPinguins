using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomWindowPresenter : MonoBehaviourPunCallbacks, IUiWindow
{
    [SerializeField] private Button _startTheGameButton;
    [SerializeField] private Button _leaveRoomButton;

    private List<Player> _playersInRoom = new();

    public static Canvas Canvas;

    public override void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
    }

    public override void OnDisable()
    {
        Canvas = null;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        _playersInRoom.Add(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        _playersInRoom.Remove(otherPlayer);
    }
}
