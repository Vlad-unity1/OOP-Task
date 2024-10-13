using CharacterInfo;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterViewDie
{
    public class CharacterView : MonoBehaviour
    {
        public Character Character { get; private set; }
        [SerializeField] private Image _healthBar;
        [SerializeField] private TextMeshProUGUI _effectsText;

        public void Initialize(Character character)
        {
            Character = character;
            Character.OnDeath += OnCharacterDeath;
            character.OnHealthChanged += UpdateHealth;
            character.OnEffectApply += EffectsShow;
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

        public void EffectsShow(EffectsType type)
        {
            _effectsText.text = type.ToString();
        }
    }
}

public enum EffectsType
{
    Debuff,
    Poison,
    Stunt,
    Vampir
}
