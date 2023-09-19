using Photon.Pun;
using System;
using UnityEngine;

public class GameEntryPoint : MonoBehaviourPunCallbacks, IEntryPoint
{
    [SerializeField] private PlayerOverviewPresenter _playerOverviewPrefab;
    [SerializeField] private GameController _gameController;
    [SerializeField] private Transform _uiContainer;
    [SerializeField] private Camera _mainCamera;

    public Camera MainCamera { get => _mainCamera; private set => _mainCamera = value; }

    public static GameEntryPoint Instance { get; private set; }

    public event Action OnUpdateEvent;
    public event Action OnFixedUpdateEvent;

    public void Update() => OnUpdateEvent?.Invoke();
    public void FixedUpdate() => OnFixedUpdateEvent?.Invoke();

    public void Start()
    {
        Instance = this;

        if (photonView.IsMine)
        {
            Instantiate(_playerOverviewPrefab, _uiContainer);
        }

        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            PhotonNetwork.InstantiateRoomObject(_gameController.name, Vector3.zero, Quaternion.identity);
        }
    }
}
