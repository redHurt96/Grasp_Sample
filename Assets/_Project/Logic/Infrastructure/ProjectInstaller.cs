using _Project.SceneManagement;
using Zenject;

namespace _Project.Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameStateSwitcher>().AsSingle();
        }
    }
}
