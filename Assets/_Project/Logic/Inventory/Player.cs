using System;
using System.Collections.Generic;

namespace _Project.Inventory
{
    public class Player
    {
        public event Action Updated;
        
        public readonly List<Item> UsedItems = new();
        public readonly List<Item> StoredItems = new();

        public void InvokeUpdate() => 
            Updated?.Invoke();
    }
}