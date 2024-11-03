using GameRestart;
using InputPlayer;
using Spawn;
using UnityEngine;
using WinnerControllerUI;

namespace StartInitializer
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private WinnerController _winnerController;

        private GameRestarter _gameRestarter;

        private void Awake()
        {
            InitializeGame();
        }

        private void Start()
        {
            StartGame();
        }

        private void InitializeGame()
        {
            _gameRestarter = new GameRestarter();

            _spawner.SpawnCharacters();
            _inputController.Initialize(_spawner);
            _winnerController.Initialize(_spawner, _gameRestarter);
        }

        private void StartGame()
        {
            _inputController.StartCyclicAttack();
        }
    }
}