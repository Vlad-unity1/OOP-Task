using CharacterInfo;
using Spawn;
using UnityEngine;
using WinnerWindowUI;

namespace CharacterViewDie
{
    public class CharacterView : MonoBehaviour
    {
        public Character Character { get; private set; }

        public void Initialize(Character character)
        {
            Character = character;
            Character.OnDeath += OnCharacterDeath;
        }

        private void OnCharacterDeath(Character character)
        {
            Character.OnDeath -= OnCharacterDeath;
            GameView.Instance.OnPlayerDeath(character);
            Object.Destroy(this.gameObject);
        }
    }
}
