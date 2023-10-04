using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomWindowPresenter : MonoBehaviourPunCallbacks, IUiWindow
{
    [SerializeField] private Button _startTheGameButton;
    [SerializeField] private Button _leaveRoomButton;
    [SerializeField] private Button _roomnameButton;
    [SerializeField] private TMP_Text _roomname;
    [SerializeField] private PlayerPrefabsList _prefabListPrefab;

    private PlayerView _playerPrefab;

    public PlayerView PlayerPrefab { get => _playerPrefab; private set => _playerPrefab = value; }

    public static Canvas Canvas;
    public static RoomWindowPresenter Instance;

    public override void OnEnable()
    {
        Instance = this;
        Canvas = GetComponent<Canvas>();

        SubscribeButtons();

        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        Instance = null;
        Canvas = null;

        UnsubscribeButtons();

        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void SubscribeButtons()
    {
        _startTheGameButton.onClick.AddListener(StartGame);
        _leaveRoomButton.onClick.AddListener(SwitchToLobbyWindow);
        _leaveRoomButton.onClick.AddListener(LeaveCurrentRoom);
        _roomnameButton.onClick.AddListener(CopyRoomnameToClipboard);
    }

    public void UnsubscribeButtons()
    {
        _startTheGameButton.onClick.RemoveListener(StartGame);
        _leaveRoomButton.onClick.RemoveListener(SwitchToLobbyWindow);
        _leaveRoomButton.onClick.RemoveListener(LeaveCurrentRoom);
        _roomnameButton.onClick.RemoveListener(CopyRoomnameToClipboard);
    }

    public void SetPlayerPrefab(PlayerView playerPrefab) => PlayerPrefab = playerPrefab;

    private void LeaveCurrentRoom()
    {
        PlayerPrefabsList.Instance.DeletePlayerPrefab(PhotonNetwork.LocalPlayer.ActorNumber);
        PhotonNetwork.LeaveRoom(false);
    }

    private void StartGame() => PhotonNetwork.LoadLevel(SceneList.SimpleGameMap.ToString());

    private void SwitchToLobbyWindow()
    {
        Canvas.enabled = false;
        LobbyPresenter.Canvas.enabled = true;
    }

    private void CopyRoomnameToClipboard() => GUIUtility.systemCopyBuffer = _roomname.text;

    public override void OnJoinedRoom()
    {
        InitRoom();
    }

    private void InitRoom()
    {
        _roomname.text = PhotonNetwork.CurrentRoom.Name;

        if (PhotonNetwork.IsMasterClient)
        {
            _startTheGameButton.interactable = true;
            PhotonNetwork.Instantiate(_prefabListPrefab.name, Vector3.zero, Quaternion.identity);
            PlayerPrefabsList.Instance.AddPlayerPrefab(PhotonNetwork.LocalPlayer.ActorNumber, PlayerPrefab);
        }
        else
        {
            _startTheGameButton.interactable = false;
            PlayerPrefabsList.Instance = FindObjectOfType<PlayerPrefabsList>();
            PlayerPrefabsList.Instance.AddPlayerPrefab(PhotonNetwork.LocalPlayer.ActorNumber, PlayerPrefab);
        }
    }
}
