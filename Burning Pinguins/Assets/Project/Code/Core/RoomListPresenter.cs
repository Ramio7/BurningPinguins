using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class RoomListPresenter : MonoBehaviourPunCallbacks, IUiWindow
{
    [SerializeField] private RoomInfoContainer _roomInfoContainerPrefab;
    [SerializeField] private Transform _roomListContainer;

    public static Canvas Canvas;

    public override void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
    }

    public override void OnDisable()
    {
        Canvas = null;
    }

    private void UpdateRoomListUI(List<RoomInfo> roomList)
    {
        foreach (RoomInfo roomInfo in roomList)
        {
            _roomInfoContainerPrefab.Init(roomInfo, _roomListContainer);
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomListUI(roomList);
    }
}
