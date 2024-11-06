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

            _spawner.FirstCharacter.OnDeath += CheckForWinner;
            _spawner.SecondCharacter.OnDeath += CheckForWinner;
        }

        private void CheckForWinner()
        {
            if (_spawner.FirstCharacter.IsAlive)
            {
                OnWinnerDeclared?.Invoke(_spawner.FirstCharacter);
            }
            else if (_spawner.SecondCharacter.IsAlive)
            {
                OnWinnerDeclared?.Invoke(_spawner.SecondCharacter);
            }
        }

        public void Dispose()
        {
            _spawner.FirstCharacter.OnDeath -= CheckForWinner;
            _spawner.SecondCharacter.OnDeath -= CheckForWinner;
        }
    }
}
