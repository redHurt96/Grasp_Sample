using UnityEngine;

namespace _Project.Infrastructure
{
    [CreateAssetMenu(menuName = "Create ItemsConfig", fileName = "ItemsConfig", order = 0)]
    public class ItemsConfig : ScriptableObject
    {
        public ItemConfig[] Items;
    }
}