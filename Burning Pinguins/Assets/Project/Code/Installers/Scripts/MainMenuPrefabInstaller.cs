using UnityEngine;
using Zenject;

public class MainMenuPrefabInstaller : MonoInstaller
{
    [SerializeField] private PlayerView _playerPrefab;

    public override void InstallBindings()
    {
        Container.Bind<PlayerView>().FromInstance(_playerPrefab).AsSingle();
    }
}