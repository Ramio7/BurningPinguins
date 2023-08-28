using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour, IEntryPoint
{
    public static MainMenuEntryPoint Instance { get; private set; }

    public event Action OnUpdateEvent;
    public event Action OnFixedUpdateEvent;

    public void Update() => OnUpdateEvent?.Invoke();

    public void FixedUpdate() => OnFixedUpdateEvent?.Invoke();

    public void Awake() => InstantiateStartingSceneObjects();

    private void InstantiateStartingSceneObjects()
    {
        Instance = this;
    }
}
