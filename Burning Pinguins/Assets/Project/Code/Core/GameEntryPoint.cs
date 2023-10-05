using Photon.Pun;
using System;
using UnityEngine;

public class GameEntryPoint : MonoBehaviourPunCallbacks, IEntryPoint
{
    [SerializeField] private PlayerOverviewPresenter _playerOverviewPrefab;
    [SerializeField] private GameController _gameControllerPrefab;
    [SerializeField] private Transform _uiContainer;

    public static GameEntryPoint Instance { get; private set; }

    public event Action OnUpdateEvent;
    public event Action OnFixedUpdateEvent;

    public void Update() => OnUpdateEvent?.Invoke();
    public void FixedUpdate() => OnFixedUpdateEvent?.Invoke();

    public void Awake()
    {
        Instance = this;

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.InstantiateRoomObject(_gameControllerPrefab.name, Vector3.zero, Quaternion.identity);
        }

        Instantiate(_playerOverviewPrefab, _uiContainer);
    }
}
