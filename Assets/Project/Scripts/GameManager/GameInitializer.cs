using Spawn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private GameView _gameView;
    private InputController _inputController;
    private Spawner _spawner;

    private void Awake()
    {
        _gameView = FindObjectOfType<GameView>();
        _inputController = FindObjectOfType<InputController>();
        _spawner = FindObjectOfType<Spawner>();

        InitializeGame();
    }

    private void InitializeGame()
    {
        _spawner.SpawnCharacters();
        _inputController.enabled = true;
    }
}
