using CharacterAttack;
using UnityEngine;

namespace Wizard
{
    public class WizardAttack : Character
    {
        public WizardAttack(string name, int damage, int hp, int effectTime)
        : base(name, damage, hp, effectTime) { }

        protected override void AttackMethod(Character opponent)
        {
            opponent.TakeDamage(Damage);
            Debug.Log($"Name {opponent.Name} + Health {opponent.HP}");
            Debug.Log($"AttackWizard + {Damage}");
            EffectManager.Instance.StartEffectWizardCoroutine(opponent, EffectTime);
        }
    }
}
