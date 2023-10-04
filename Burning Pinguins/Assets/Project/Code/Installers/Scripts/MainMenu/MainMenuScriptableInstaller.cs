using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = nameof(MainMenuScriptableInstaller), menuName = "Installers/" + nameof(MainMenuScriptableInstaller))]
public class MainMenuScriptableInstaller : ScriptableObjectInstaller
{
    [SerializeField] private PlayerGameCharacteristics _playerGameCharacteristics;

    public override void InstallBindings()
    {
        Container.Bind<PlayerGameCharacteristics>().FromInstance(_playerGameCharacteristics).AsSingle();
    }
}