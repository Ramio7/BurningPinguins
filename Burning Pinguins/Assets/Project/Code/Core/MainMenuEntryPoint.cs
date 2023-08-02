using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour, IEntryPoint
{
    [SerializeField] private MainMenuPresenter _mainMenuPresenterPrefab;
    [SerializeField] private PhotonService _photonService;
    [SerializeField] private PlayFabService _playFabService;

    public event Action OnUpdateEvent;
    public event Action OnFixedUpdateEvent;

    private void Update() => OnUpdateEvent?.Invoke();
    private void FixedUpdate() => OnFixedUpdateEvent?.Invoke();
}
