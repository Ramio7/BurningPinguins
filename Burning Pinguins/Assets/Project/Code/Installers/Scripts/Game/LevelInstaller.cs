using Zenject;

public class LevelInstaller : Installer<LevelInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<LevelModel>().AsTransient();
    }
}