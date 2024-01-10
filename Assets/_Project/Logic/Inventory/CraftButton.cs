using System.Linq;
using _Project.Infrastructure;
using UniRx;
using UnityEngine.UI;
using Zenject;
using UnityEngine;
using static UnityEngine.Random;
using static System.Enum;

namespace _Project.Inventory
{
    public class CraftButton : MonoBehaviour
    {
        private Player _player;
        private ItemsConfig _config;

        [Inject]
        private void Construct(Player player, ItemsConfig config)
        {
            _config = config;
            _player = player;
        }

        private void Start() =>
            GetComponent<Button>().onClick
                .AsObservable()
                .Subscribe(_ => CraftItem())
                .AddTo(this);

        private void CraftItem()
        {
            Slot slot = (Slot)Range(0, GetValues(typeof(Slot)).Length);
            ItemConfig config = _config.Items.First(x => x.Slot == slot);
            Item item = new(slot,
                $"{slot}_{Range(0, 1000)}",
                Range(config.MinCharm, config.MaxCharm),
                Range(config.MinDamage, config.MaxDamage));
            
            _player.StoredItems.Add(item);
            _player.InvokeUpdate();
        }
    }
}