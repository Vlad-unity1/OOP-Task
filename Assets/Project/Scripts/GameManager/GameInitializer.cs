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

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        _spawner.SpawnCharacters();
        Character[] activeCharacters = _spawner.ActiveCharacters.ToArray();
        _winnerCheckUI.Intialize(activeCharacters);
        _inputController.StartCyclicAttack();
    }
}
