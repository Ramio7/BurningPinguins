using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoContainer : MonoBehaviour
{
    [SerializeField] private Button _playerInfoContainerPrefab;

    private Player _playerInfo;
    private Button _container;

    public Player PlayerInfo { get => _playerInfo; private set => _playerInfo = value; }

    public void Init(Player playerInfo, Transform uiContainer)
    {
        _playerInfo = playerInfo;
        _container = Instantiate(_playerInfoContainerPrefab, uiContainer);
        _container.GetComponentInChildren<TMP_Text>().text = playerInfo.ToStringFull();
    }

    private void OnDestroy()
    {
        
    }
}
