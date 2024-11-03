using System;
using CharacterInfo;
using Spawn;

namespace WinnerModelUI
{
    public class WinnerModel
    {
        public event Action<Character> OnWinnerDeclared;
        private readonly Spawner _spawner;

        public WinnerModel(Spawner spawner)
        {
            _spawner = spawner;

            foreach (Character character in _spawner.ActiveCharacters)
            {
                character.OnDeath += CheckForWinner;
            }
        }

        private void CheckForWinner()
        {
            foreach (Character character in _spawner.ActiveCharacters)
            {
                if (character.IsAlive)
                {
                    OnWinnerDeclared?.Invoke(character);
                    break;
                }
            }
        }

        public void Dispose()
        {
            foreach (Character character in _spawner.ActiveCharacters)
            {
                character.OnDeath -= CheckForWinner;
            }
        }
    }
}
