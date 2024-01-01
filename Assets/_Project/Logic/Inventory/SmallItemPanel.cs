using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Inventory
{
    public class SmallItemPanel : MonoBehaviour
    {
        [SerializeField] private Button _replace;
        [SerializeField] private Text _name;
        [SerializeField] private Image _betterMark;
        
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
            _name.text = $"{item.Slot}_{item.Name}";
            _betterMark.enabled = CheckItemBetter();
        } 

        private void Move()
        {
            _player.StoredItems.Remove(_item);
            _player.UsedItems.Add(_item);
            _player.InvokeUpdate();
        }

        private bool CheckItemBetter()
        {
            Item toCompare = _player.UsedItems.Find(x => x.Slot == _item.Slot);
            
            if (toCompare == null)
                return true;

            int originStatsSum = _item.Charm + _item.Damage;
            int toCompareStatsSum = toCompare.Charm + toCompare.Damage;

            return originStatsSum > toCompareStatsSum;
        }
    }
}