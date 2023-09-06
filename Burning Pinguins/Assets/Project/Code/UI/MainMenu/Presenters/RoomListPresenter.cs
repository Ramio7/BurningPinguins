using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListPresenter : MonoBehaviourPunCallbacks, IUiWindow
{
    [SerializeField] private Button _roomInfoContainerPrefab;
    [SerializeField] private Transform _roomListContainer;

    private List<RoomInfoContainer> _rooms = new();

    public static Canvas Canvas;

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
        Canvas = GetComponent<Canvas>();
    }

    public override void OnDisable()
    {
        Canvas = null;
        ClearRoomList();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomListUI(roomList);
    }

    private void UpdateRoomListUI(List<RoomInfo> roomList)
    {
        ClearRoomList();

        foreach (var roomInfo in roomList)
        {
            _rooms.Add(new(roomInfo, _roomListContainer, _roomInfoContainerPrefab));
        }
    }

    private void ClearRoomList()
    {
        foreach (var roomInfo in _rooms)
        {
            Destroy(roomInfo.gameObject);
        }
    }
}
