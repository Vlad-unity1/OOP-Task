using CharacterInfo;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterViewDie
{
    public class CharacterView : MonoBehaviour
    {
        public Character Character { get; private set; }
        [SerializeField] private Image _healthBar;

        public void Initialize(Character character)
        {
            Character = character;
            Character.OnDeath += OnCharacterDeath;
            character.OnHealthChanged += UpdateHealth;
        }

        private void OnCharacterDeath(Character character)
        {
            Character.OnDeath -= OnCharacterDeath;
            GameView.Instance.OnPlayerDeath(character);
            Object.Destroy(this.gameObject);
        }

        public void UpdateHealth(int currentHealth)
        {
            _healthBar.fillAmount = (float)currentHealth / Character.HP;
        }
    }
}
