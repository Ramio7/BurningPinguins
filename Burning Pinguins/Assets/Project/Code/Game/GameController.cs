using Photon.Pun;
using UnityEngine;

public class GameController : MonoBehaviourPunCallbacks
{
    [SerializeField] private PlayerController _playerPrefab;

    public override void OnEnable()
    {
        Instantiate(_playerPrefab);
    }
}
