using RH_Modules.Utilities.UI;
using UnityEngine;
using Zenject;

namespace _Project.SceneManagement
{
    public class SwitchSceneButton : BaseActionButton
    {
        [SerializeField] private GameState _target;
        
        private GameStateSwitcher _gameStateSwitcher;

        [Inject]
        private void Construct(GameStateSwitcher gameStateSwitcher) => 
            _gameStateSwitcher = gameStateSwitcher;

        protected override void PerformOnStart()
        {
            base.PerformOnStart();
            gameObject.SetActive(!_gameStateSwitcher.CompareState(_target));
        }

        protected override void PerformOnClick() => 
            _gameStateSwitcher.TransitTo(_target);
    }
}
