using _Project.Inventory;
using Zenject;
using static System.Enum;
using static UnityEngine.Random;

namespace _Project.Infrastructure
{
    public class EntryPoint : IInitializable
    {
        private readonly Player _player;

        public EntryPoint(Player player) => 
            _player = player;

        public void Initialize()
        {
            for (int i = 0; i < 18; i++)
                _player.StoredItems.Add(CreateRandomItem());
        }

        private Item CreateRandomItem() =>
            new((Slot)Range(0, GetValues(typeof(Slot)).Length),
                Range(0, 1000).ToString(),
                Range(0, 100),
                Range(0, 100));
    }
}