using Photon.Pun;
using System;
using UnityEngine;

public class GameEntryPoint : MonoBehaviourPunCallbacks, IEntryPoint
{
    [SerializeField] private PlayerOverviewPresenter _playerOverviewPrefab;
    [SerializeField] private GameController _gameController;
    [SerializeField] private Transform _uiContainer;

    public event Action OnUpdateEvent;
    public event Action OnFixedUpdateEvent;

    public void Update() => OnUpdateEvent?.Invoke();
    public void FixedUpdate() => OnFixedUpdateEvent?.Invoke();

    public void Start()
    {
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
