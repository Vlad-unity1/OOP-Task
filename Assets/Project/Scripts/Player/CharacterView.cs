using CharacterInfo;
using EffectApply;
using EffectVisualization;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterViewDie
{
    [RequireComponent(typeof(Effect))]
    public class CharacterView : MonoBehaviour
    {
        [field: SerializeField] public Effect Effect { get; private set; }

        [SerializeField] private Image _healthBar;
        [SerializeField] private EffectVisual _effectVisual;

        private Character _character;
        
        public void Initialize(Character character)
        {
            _character = character;
            _character.OnDeath += OnCharacterDeath;
            _character.OnHealthChanged += UpdateHealth;
            _character.OnEffectApply += EffectsShow;
        }

        private void Dispose()
        {
            _character.OnDeath -= OnCharacterDeath;
            _character.OnEffectApply -= EffectsShow;
            _character.OnHealthChanged -= UpdateHealth;
        }

        private void OnCharacterDeath()
        {
            Dispose();
            Destroy(gameObject);
        }

        private void UpdateHealth()
        {
            _healthBar.fillAmount = (float)_character.CurrentHp / _character.HP;
        }

        private void EffectsShow(string type)
        {
            _effectVisual.ShowEffect(type, Effect.EffectTime);
        }
    }
}
