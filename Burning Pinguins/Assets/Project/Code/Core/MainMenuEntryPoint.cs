using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour, IEntryPoint
{
    [SerializeField] private GameObject _uiPrefab;

    public static MainMenuEntryPoint Instance { get; private set; }

    public event Action OnUpdateEvent;
    public event Action OnFixedUpdateEvent;

    private void Start() => InstantiateStartingSceneObjects();

    public void Update() => OnUpdateEvent?.Invoke();

    public void FixedUpdate() => OnFixedUpdateEvent?.Invoke();

    private void InstantiateStartingSceneObjects()
    {
        Instance = this;
        InitMenu();
    }

    private void InitMenu()
    {
        Instantiate(_uiPrefab);
        MainMenuPresenter.Canvas.enabled = true;
    }
}
