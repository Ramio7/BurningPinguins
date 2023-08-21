using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour, IEntryPoint
{
    [SerializeField] private MainMenuPresenter _mainMenuPresenterPrefab;
    [SerializeField] private PhotonService _photonService;
    [SerializeField] private PlayFabService _playFabService;

    public static MainMenuEntryPoint Instance { get; private set; }

    public event Action OnUpdateEvent;
    public event Action OnFixedUpdateEvent;

    public void Update() => OnUpdateEvent?.Invoke();

    public void FixedUpdate() => OnFixedUpdateEvent?.Invoke();

    public void Awake() => InstantiateStartingSceneObjects();

    private void InstantiateStartingSceneObjects()
    {
        Instance = this;

        Instantiate(_mainMenuPresenterPrefab);Instantiate(_photonService).GetComponent<PhotonService>();
        Instantiate(_playFabService).GetComponent<PlayFabService>();
    }
}
