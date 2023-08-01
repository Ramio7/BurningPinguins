using Photon.Pun;

public class PhotonService : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
}
