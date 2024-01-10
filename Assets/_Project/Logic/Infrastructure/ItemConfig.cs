using System;
using _Project.Inventory;

namespace _Project.Infrastructure
{
    [Serializable]
    public class ItemConfig
    {
        public Slot Slot;
        
        public int MinCharm;
        public int MaxCharm;
        
        public int MinDamage;
        public int MaxDamage;
    }
}