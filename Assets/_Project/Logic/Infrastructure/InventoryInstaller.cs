using _Project.Inventory;
using UnityEngine;
using Zenject;

namespace _Project.Infrastructure
{
    public class InventoryInstaller : MonoInstaller
    {
        [SerializeField] private ItemsConfig _itemsConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<Player>().AsSingle();
            Container.Bind<ItemsConfig>().FromInstance(_itemsConfig).AsSingle();
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle();
        }
    }
}