using CharacterInfo;
using InputPlayer;
using Spawn;
using UnityEngine;
using WinnerWindowUI;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private WinnerCheckUI _winnerCheckUI;

    private void Awake()
    {
        InitializeGame();
    }

    private void Start()
    {
        _spawner.SpawnCharacters();
        _inputController.StartCyclicAttack();
    }

    private void InitializeGame()
    {
        Character[] activeCharacters = _spawner.ActiveCharacters.ToArray();
        _winnerCheckUI.Intialize(activeCharacters);
    }
}
