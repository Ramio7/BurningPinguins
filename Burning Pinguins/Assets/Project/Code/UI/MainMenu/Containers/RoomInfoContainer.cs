using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomInfoContainer : MonoBehaviour
{
    [SerializeField] private Button _roomInfoContainerPrefab;

    private RoomInfo _roomInfo;
    private Button _container;

    public RoomInfo RoomInfo { get => _roomInfo; private set => _roomInfo = value; }

    public RoomInfoContainer Init(RoomInfo roomInfo, Transform uiContainer)
    {
        _roomInfo = roomInfo;
        _container = Instantiate(_roomInfoContainerPrefab, uiContainer);
        _container.GetComponentInChildren<TMP_Text>().text = roomInfo.ToStringFull();
        _container.onClick.AddListener(JoinRoom);
        return this;
    }

    public void OnDisable()
    {
        _container.onClick.RemoveListener(JoinRoom);
    }

    private void JoinRoom() => PhotonNetwork.JoinRoom(_roomInfo.Name);
}
