using Photon.Pun;
using Photon.Realtime;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class PhotonService : MonoBehaviourPunCallbacks
{
    private TypedLobby _lobby = new("mainLobby", LobbyType.SqlLobby);
    private const string MAP_KEY = "C0";
    private const string RATING_KEY = "C1";

    public static Action OnRoomJoin;
    public static PhotonService Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public override void OnEnable()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = PhotonNetwork.AppVersion;
        PhotonNetwork.AddCallbackTarget(this);
        PhotonNetwork.ConnectUsingSettings();
        
    }

    public override void OnDisable()
    {
        Instance = null;
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public async void ConnectLobby()
    {
        PlayerAccountData accountData = PlayFabService.Instance.LoggedAccountData;
        PhotonNetwork.AuthValues = new();
        PhotonNetwork.NickName = accountData.AccountName;
        PhotonNetwork.JoinLobby(_lobby);
        await Task.Run(() => WaitLobbyJoinAsync());
        GetRoomList();
    }

    public void JoinGame()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
        PhotonNetwork.LoadLevel(SceneList.SimpleGameMap.ToString());
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"{message}. Code: {returnCode}");
    }

    public override void OnJoinedRoom()
    {
        OnRoomJoin?.Invoke();
    }

    private void GetRoomList()
    {
        var roomFilter = $"{MAP_KEY} >= 0 AND {RATING_KEY} >= 0";
        PhotonNetwork.GetCustomRoomList(_lobby, roomFilter);
    }

    private Task WaitLobbyJoinAsync()
    {
        while (PhotonNetwork.NetworkClientState != ClientState.JoinedLobby) Task.Delay(1);
        return Task.CompletedTask;
    }
}
