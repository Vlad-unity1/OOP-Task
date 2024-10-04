using CharacterInfo;
using DebuffEffectSystem;
using UnityEngine;

namespace CharacterWizard
{
    public class Wizard : Character
    {
        private readonly DebuffEffect _debuffEffect;

        public Wizard(string name, int damage, int hp, int effectTime, DebuffEffect debuffEffect)
        : base(name, damage, hp, effectTime) 
        { 
            _debuffEffect = debuffEffect;
        }

        public override void AttackMethod(Character opponent)
        {
            opponent.TakeDamage(Damage);
            Debug.Log($"Name {opponent.Name} + Health {opponent.HP}");
            Debug.Log($"AttackWizard + {Damage}");
            _debuffEffect.StartEffectWizardCoroutine(opponent, EffectTime);
        }
    }
}
