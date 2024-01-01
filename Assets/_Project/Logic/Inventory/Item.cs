namespace _Project.Inventory
{
    public class Item
    {
        public readonly Slot Slot;
        public readonly string Name;
        public readonly int Charm;
        public readonly int Damage;

        public Item(Slot slot, string name, int charm, int damage)
        {
            Slot = slot;
            Name = name;
            Charm = charm;
            Damage = damage;
        }
    }
}