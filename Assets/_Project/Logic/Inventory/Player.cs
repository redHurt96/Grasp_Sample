using System;
using System.Collections.Generic;

namespace _Project.Inventory
{
    public class Player
    {
        public event Action Updated;

        public IReadOnlyCollection<Item> UsedItems => _usedItems;
        public IReadOnlyCollection<Item> StoredItems => _storedItems;
        
        private readonly List<Item> _usedItems = new();
        private readonly List<Item> _storedItems = new();

        public void Store(Item item)
        {
            if (_usedItems.Contains(item))
                _usedItems.Remove(item);
            
            _storedItems.Add(item);
            Updated?.Invoke();
        }

        public void Use(Item item)
        {
            _storedItems.Remove(item);
            _usedItems.Add(item);
            Updated?.Invoke();
        }

        public bool IsItemBetterThanUsed(Item item)
        {
            Item toCompare = _usedItems.Find(x => x.Slot == item.Slot);
            
            if (toCompare == null)
                return true;

            int originStatsSum = item.Charm + item.Damage;
            int toCompareStatsSum = toCompare.Charm + toCompare.Damage;

            return originStatsSum > toCompareStatsSum;
        }
    }
}