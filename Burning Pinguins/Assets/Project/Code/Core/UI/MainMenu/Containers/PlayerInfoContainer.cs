using Photon.Realtime;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoContainer: IDisposable
{
    private Player _playerInfo;
    private Button _container;

    public Player PlayerInfo { get => _playerInfo; private set => _playerInfo = value; }
    public Button Container { get => _container; }

    public PlayerInfoContainer(Player playerInfo, Transform uiContainer, Button playerInfoContainerPrefab)
    {
        InitPlayerContainer(playerInfo, uiContainer, playerInfoContainerPrefab);
        UpdatePlayerInfo(playerInfo);
    }

    private void InitPlayerContainer(Player playerInfo, Transform uiContainer, Button playerInfoContainerPrefab)
    {
        _playerInfo = playerInfo;
        _container = UnityEngine.Object.Instantiate(playerInfoContainerPrefab, uiContainer);
    }

    private void UpdatePlayerInfo(Player playerInfo)
    {
        _container.GetComponentInChildren<TMP_Text>().text = playerInfo.ToStringFull();
    }

    public void Dispose()
    {
        _playerInfo = null;
        UnityEngine.Object.Destroy(_container);
    }
}
