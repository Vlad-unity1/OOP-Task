using InputPlayer;
using Spawn;
using UnityEngine;
using WinnerControllerUI;
using WinnerModelUI;
using WinnerViewUI;

namespace StartInitializer
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private WinnerView _winnerView;

        private WinnerController _winnerController;

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
            _spawner.SpawnCharacters();
            _inputController.Initialize(_spawner);

            WinnerModel winnerModel = new(_spawner);
            _winnerController = new WinnerController(winnerModel, _winnerView);
        }

        private void StartGame()
        {
            _inputController.StartCyclicAttack();
        }
    }
}