using UnityEngine;
using Zenject;

namespace _Project.Inventory
{
    public class StoredItemsPanel : MonoBehaviour
    {
        [SerializeField] private Transform _anchor;
        [SerializeField] private SmallItemPanel _resource;
        
        private Player _player;
        private IInstantiator _instantiator;

        [Inject]
        private void Construct(Player player, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _player = player;
        }

        private void Start()
        {
            UpdateView();
            _player.Updated += UpdateView;
        }

        private void OnDestroy() => 
            _player.Updated -= UpdateView;

        private void UpdateView()
        {
            foreach (Transform child in _anchor)
                Destroy(child.gameObject);

            foreach (Item item in _player.StoredItems)
            {
                SmallItemPanel panel = _instantiator.InstantiatePrefabForComponent<SmallItemPanel>(_resource, _anchor);
                panel.SetItem(item);
            }
        }
    }
}