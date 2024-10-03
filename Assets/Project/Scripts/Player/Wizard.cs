using CharacterAttack;
using UnityEngine;

namespace Wizard
{
    public class WizardAttack : Character
    {
        private readonly DebuffEffect _debuffEffect;

        public WizardAttack(string name, int damage, int hp, int effectTime)
        : base(name, damage, hp, effectTime) { }

        public override void AttackMethod(Character opponent)
        {
            opponent.TakeDamage(Damage);
            Debug.Log($"Name {opponent.Name} + Health {opponent.HP}");
            Debug.Log($"AttackWizard + {Damage}");
            _debuffEffect.StartEffectWizardCoroutine(opponent, EffectTime);
        }
    }
}
