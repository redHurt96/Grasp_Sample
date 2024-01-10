using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Inventory
{
    public class UsedItemView : MonoBehaviour
    {
        [SerializeField] private Button _replace;
        [SerializeField] private Text _name;
        [SerializeField] private Text _charm;
        [SerializeField] private Text _damage;
        
        private Player _player;
        private Item _item;

        [Inject]
        private void Construct(Player player) => 
            _player = player;

        private void Start() => 
            _replace.onClick.AsObservable().Subscribe(_ => Move()).AddTo(this);

        public void SetItem(Item item)
        {
            _item = item;
            _name.text = item.Name;
            _charm.text = $"Charm +{item.Charm}";
            _damage.text = $"Damage +{item.Damage}";
        }

        private void Move()
        {
            _player.UsedItems.Remove(_item);
            _player.StoredItems.Add(_item);
            _player.InvokeUpdate();
        }
    }
}
