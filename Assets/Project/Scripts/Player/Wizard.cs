using CharacterInfo;
using DebuffEffectSystem;
using UnityEngine;

namespace CharacterWizard
{
    public class Wizard : Character
    {
        private readonly DebuffEffect _debuffEffect;

        public Wizard(int damage, int hp, int effectTime, DebuffEffect debuffEffect)
        : base(damage, hp, effectTime, CharacterType.Wizard) 
        { 
            _debuffEffect = debuffEffect;
        }

        public override void ToAttack(Character opponent)
        {
            if(opponent.IsAlive)
            {
                opponent.TakeDamage(Damage, _debuffEffect.GetEffectType());
                _debuffEffect.EffectDebuff(opponent, EffectTime);
            }
        }
    }
}
