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
                _player.Store(CreateRandomItem());
        }

        private Item CreateRandomItem()
        {
            return new((Slot)Range(0, GetValues(typeof(Slot)).Length),
                 $"Item_{Range(0, 1000)}",
                Range(0, 100),
                Range(0, 100));
        }
    }
}