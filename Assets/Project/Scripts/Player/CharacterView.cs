using CharacterInfo;
using UnityEngine;

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
            Object.Destroy(this.gameObject);
        }
    }

}
