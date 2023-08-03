using Photon.Pun;
using Photon.Realtime;

public class PhotonService : MonoBehaviourPunCallbacks
{
    private TypedLobby _lobby = new("mainLobby", LobbyType.SqlLobby);
    private const string MAP_KEY = "C0";
    private const string RATING_KEY = "C1";

    public override void OnEnable()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = PhotonNetwork.AppVersion;
        PhotonNetwork.AddCallbackTarget(this);
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ConnectLobby(PlayerAccountData accountData)
    {
        PhotonNetwork.AuthValues = new();
        PhotonNetwork.NickName = accountData.accountName;
        PhotonNetwork.JoinLobby(_lobby);
        GetRoomList();
    }

    private void GetRoomList()
    {
        var roomFilter = $"{MAP_KEY} >= 0 AND {RATING_KEY} >= 0";
        PhotonNetwork.GetCustomRoomList(_lobby, roomFilter);
    }
}
