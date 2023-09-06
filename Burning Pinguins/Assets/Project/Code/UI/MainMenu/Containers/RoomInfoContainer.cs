using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomInfoContainer : MonoBehaviourPunCallbacks
{
    private RoomInfo _roomInfo;
    private Button _containerButton;

    public RoomInfo RoomInfo { get => _roomInfo; private set => _roomInfo = value; }

    public RoomInfoContainer(RoomInfo roomInfo, Transform uiContainer, Button roomInfoContainerPrefab)
    {
        InitRoomContainer(roomInfo, uiContainer, roomInfoContainerPrefab);
        UpdateRoomInfoText();
    }

    public void OnDestroy()
    {
        _containerButton.onClick.RemoveListener(JoinRoom);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) => UpdateRoomInfoText();

    public override void OnPlayerLeftRoom(Player otherPlayer) => UpdateRoomInfoText();

    private void InitRoomContainer(RoomInfo roomInfo, Transform uiContainer, Button roomInfoContainerPrefab)
    {
        _roomInfo = roomInfo;
        _containerButton = Instantiate(roomInfoContainerPrefab, uiContainer);
        _containerButton.onClick.AddListener(JoinRoom);
    }

    private void JoinRoom() => PhotonNetwork.JoinRoom(_roomInfo.Name);

    private void UpdateRoomInfoText() => _containerButton.GetComponentInChildren<TMP_Text>().text = _roomInfo.ToStringFull();
}
