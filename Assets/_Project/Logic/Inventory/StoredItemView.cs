using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Inventory
{
    public class StoredItemView : MonoBehaviour
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
            _replace.onClick.AsObservable().Subscribe(_ => _player.Use(_item)).AddTo(this);

        public void SetItem(Item item)
        {
            _item = item;
            _name.text = item.FullName;
            _betterMark.enabled = _player.IsItemBetterThanUsed(_item);
        } 
    }
}