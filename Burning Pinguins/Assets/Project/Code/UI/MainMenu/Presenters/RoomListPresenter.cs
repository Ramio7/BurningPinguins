using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListPresenter : MonoBehaviourPunCallbacks, IUiList
{
    [SerializeField] private Button _roomInfoContainerPrefab;
    [SerializeField] private Transform _roomListContainer;

    private List<RoomInfoContainer> _rooms = new();

    public Transform ListTransform { get => _roomListContainer; private set => _roomListContainer = value; }

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        ClearRoomListUi();
        _rooms.Clear();
    }

    public override void OnJoinedLobby()
    {
        PhotonService.Instance.GetRoomList();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList) => UpdateRoomListUI(roomList);

    private void UpdateRoomListUI(List<RoomInfo> roomList)
    {
        ClearRoomListUi();

        foreach (var roomInfo in roomList)
        {
            _rooms.Add(new(roomInfo, _roomListContainer, _roomInfoContainerPrefab));
        }
    }

    private void ClearRoomListUi()
    {
        foreach (var roomInfo in _rooms)
        {
            Destroy(roomInfo.gameObject);
        }
    }
}
