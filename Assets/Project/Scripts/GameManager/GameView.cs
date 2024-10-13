using CharacterInfo;
using Spawn;
using UnityEngine;
using WinnerWindowUI;

public class GameView : MonoBehaviour
{
    public static GameView Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void OnPlayerDeath(Character type)
    {
        Character winner = GetWinner();
        if (winner != null) // тут ошибка может быть раз через раз виннер нулл перед рестартом
        {
            WinnerCheckUI.Instance.ShowWinner(winner.Type);
        }
    }

    private Character GetWinner()
    {
        int aliveCount = 0;
        Character lastAliveCharacter = null;

        foreach (var character in Spawner.Instance.ActiveCharacters)
        {
            if (character.IsAlive)
            {
                aliveCount++;
                lastAliveCharacter = character;
            }
        }

        return aliveCount == 1 ? lastAliveCharacter : null;
    }
}
