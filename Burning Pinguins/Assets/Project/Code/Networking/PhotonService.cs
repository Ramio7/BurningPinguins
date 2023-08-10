using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine;

public class PhotonService : MonoBehaviourPunCallbacks
{
    private TypedLobby _lobby = new("mainLobby", LobbyType.SqlLobby);
    private const string MAP_KEY = "C0";
    private const string RATING_KEY = "C1";

    public static Action OnRoomJoin;

    public override void OnEnable()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = PhotonNetwork.AppVersion;
        PhotonNetwork.AddCallbackTarget(this);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void ConnectLobby(PlayerAccountData accountData)
    {
        PhotonNetwork.AuthValues = new();
        PhotonNetwork.NickName = accountData.AccountName;
        PhotonNetwork.JoinLobby(_lobby);
        GetRoomList();
    }

    public void JoinGame()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
        PhotonNetwork.LoadLevel(SceneList.SimpleGameMap.ToString());
    }

    private void GetRoomList()
    {
        var roomFilter = $"{MAP_KEY} >= 0 AND {RATING_KEY} >= 0";
        PhotonNetwork.GetCustomRoomList(_lobby, roomFilter);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"{message}. Code: {returnCode}");
    }

    public override void OnJoinedRoom()
    {
        OnRoomJoin?.Invoke();
    }
}
