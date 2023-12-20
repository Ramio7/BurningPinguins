using Photon.Pun;
using Photon.Realtime;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class PhotonService : MonoBehaviourPunCallbacks
{
    public string AppVersion; 
    //private TypedLobby _lobby = new("mainLobby", LobbyType.SqlLobby);
    //private const string MAP_KEY = "C0";
    //private const string RATING_KEY = "C1";

    //public TypedLobby CurrentLobby { get => _lobby; private set => _lobby = value; }

    public static PhotonService Instance { get; private set; }

    public event Action OnConnectedToServer;
    public event Action OnConnectedToLobby;

    private void Awake()
    {
        Instance = this;
    }

    public override void OnEnable()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = AppVersion;
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        Instance = null;
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public async void ConnectToPhotonServer()
    {
        PlayerAccountData accountData = PlayFabService.Instance.LoggedAccountData;
        PhotonNetwork.AuthValues = new();
        PhotonNetwork.NickName = accountData.AccountName;
        PhotonNetwork.ConnectUsingSettings();
        await Task.Run(() => WaitServerJoinAsync());
        OnConnectedToServer?.Invoke();
    }

    public async void ConnectLobby()
    {
        //PhotonNetwork.JoinLobby(_lobby);
        PhotonNetwork.JoinLobby();
        await Task.Run(() => WaitLobbyJoinAsync());
        //GetRoomList();
        OnConnectedToLobby?.Invoke();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"{message}. Code: {returnCode}");
    }

    public Task WaitServerJoinAsync()
    {
        while (PhotonNetwork.NetworkClientState != ClientState.ConnectedToMasterServer) Task.Delay(1);
        return Task.CompletedTask;
    }

    public Task WaitLobbyJoinAsync()
    {
        while (PhotonNetwork.NetworkClientState != ClientState.JoinedLobby) Task.Delay(1);
        return Task.CompletedTask;
    }

    //public void GetRoomList()
    //{
    //    var roomFilter = $"{MAP_KEY} >= 0 AND {RATING_KEY} >= 0";
    //    PhotonNetwork.GetCustomRoomList(_lobby, roomFilter);
    //}
}
