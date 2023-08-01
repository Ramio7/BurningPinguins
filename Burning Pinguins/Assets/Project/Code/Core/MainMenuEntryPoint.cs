using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour, IEntryPoint
{
    [SerializeField] private MainMenuPresenter _mainMenuPresenterPrefab;

    public event Action OnUpdateEvent;
    public event Action OnFixedUpdateEvent;

    private void Update() => OnUpdateEvent?.Invoke();
    private void FixedUpdate() => OnFixedUpdateEvent?.Invoke();
}
