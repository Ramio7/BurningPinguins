using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour, IEntryPoint
{
    [SerializeField] private MainMenuPresenter _mainMenuPresenterPrefab;
    [SerializeField] private PhotonService _photonService;
    [SerializeField] private PlayFabService _playFabService;

    public static PhotonService PhotonService;
    public static PlayFabService PlayFabService;

    public event Action OnUpdateEvent;
    public event Action OnFixedUpdateEvent;

    private void Update() => OnUpdateEvent?.Invoke();
    private void FixedUpdate() => OnFixedUpdateEvent?.Invoke();

    private void Awake()
    {
        InstantiateStartingSceneObjects();
    }

    private void InstantiateStartingSceneObjects()
    {
        Instantiate(_mainMenuPresenterPrefab);
        PhotonService = Instantiate(_photonService).GetComponent<PhotonService>();
        PlayFabService = Instantiate(_playFabService).GetComponent<PlayFabService>();
    }
}
