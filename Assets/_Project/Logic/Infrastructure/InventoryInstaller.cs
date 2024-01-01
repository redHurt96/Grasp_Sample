using _Project.Inventory;
using Zenject;

namespace _Project.Infrastructure
{
    public class InventoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Player>().AsSingle();
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle();
        }
    }
}