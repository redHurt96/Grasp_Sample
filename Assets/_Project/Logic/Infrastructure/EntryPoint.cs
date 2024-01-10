using System.Linq;
using _Project.Inventory;
using Zenject;
using static System.Enum;
using static UnityEngine.Random;

namespace _Project.Infrastructure
{
    public class EntryPoint : IInitializable
    {
        private readonly Player _player;
        private readonly ItemsConfig _itemsConfig;

        public EntryPoint(Player player, ItemsConfig itemsConfig)
        {
            _player = player;
            _itemsConfig = itemsConfig;
        }

        public void Initialize()
        {
            for (int i = 0; i < 10; i++)
                _player.StoredItems.Add(CreateRandomItem());
        }

        private Item CreateRandomItem()
        {
            Slot slot = (Slot)Range(0, GetValues(typeof(Slot)).Length);
            ItemConfig config = _itemsConfig.Items.First(x => x.Slot == slot);

            return new(slot,
                 $"{slot}_{Range(0, 1000)}",
                Range(config.MinCharm, config.MaxCharm),
                 Range(config.MinDamage, config.MaxDamage));
        }
    }
}