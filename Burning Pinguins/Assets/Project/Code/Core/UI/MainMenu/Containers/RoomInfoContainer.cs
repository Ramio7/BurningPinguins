using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class RoomInfoContainer : MonoBehaviourPunCallbacks
{
    private RoomInfo _roomInfo;
    private Button _containerButton;

    public RoomInfo RoomInfo { get => _roomInfo; private set => _roomInfo = value; }
    public Button Container { get => _containerButton; }

    public void InitRoomContainer(RoomInfo roomInfo)
    {
        _roomInfo = roomInfo;
        _containerButton = gameObject.GetComponent<Button>();
        _containerButton.onClick.AddListener(JoinRoom);
    }

    public void OnDestroy()
    {
        _containerButton.onClick.RemoveListener(JoinRoom);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) => UpdateRoomInfoText();

    public override void OnPlayerLeftRoom(Player otherPlayer) => UpdateRoomInfoText();

    private void JoinRoom() => PhotonNetwork.JoinRoom(_roomInfo.Name);

    private void UpdateRoomInfoText() => _containerButton.GetComponentInChildren<TMP_Text>().text = _roomInfo.ToStringFull();
}
