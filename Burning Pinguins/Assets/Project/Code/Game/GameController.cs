using Photon.Pun;
using UnityEngine;

public class GameController : MonoBehaviourPunCallbacks
{
    [SerializeField] private PlayerController _playerPrefab;

    private Camera MainCamera => GameEntryPoint.Instance.MainCamera;

    public override void OnEnable()
    {
        Instantiate(_playerPrefab); //допиши код на инициацию игры
    }
}
