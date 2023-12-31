using Zenject;
using static System.Enum;
using static UnityEngine.Debug;
using static UnityEngine.SceneManagement.SceneManager;

namespace _Project.SceneManagement
{
    internal class GameStateSwitcher : IInitializable
    {
        private GameState _state;

        public void Initialize() => 
            _state = Parse<GameState>(GetActiveScene().name);

        public bool CompareState(GameState with) =>
            _state == with;

        public void TransitTo(GameState target)
        {
            if (CompareState(target))
            {
                LogError($"Cannot transit to current state - {target}");
                return;
            }

            _state = target;
            LoadScene(target.ToString());
        }
    }
}