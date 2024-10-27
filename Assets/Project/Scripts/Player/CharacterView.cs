using CharacterInfo;
using EffectApply;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterViewDie
{
    [RequireComponent(typeof(Effect))]
    public class CharacterView : MonoBehaviour
    {
        [field:SerializeField] public Effect Effect {  get; private set; }
        [SerializeField] private Image _healthBar;
        [SerializeField] private TextMeshProUGUI _effectsText;
        private Character _character;

        public void Initialize(Character character)
        {
            _character = character;
            _character.OnDeath += OnCharacterDeath;
            character.OnHealthChanged += UpdateHealth;
            character.OnEffectApply += EffectsShow;
        }

        private void OnCharacterDeath(Character character)
        {
            Dispose();
            Destroy(gameObject);
        }

        private void Dispose()
        {
            _character.OnDeath -= OnCharacterDeath;
            _character.OnEffectApply -= EffectsShow;
        }
        
        private void UpdateHealth(int currentHealth)
        {
            _healthBar.fillAmount = (float)currentHealth / _character.HP;
        }

        private void EffectsShow(string type)
        {
            _effectsText.text = type;
        }
    }
}
