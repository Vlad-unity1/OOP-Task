using CharacterAttack;
using UnityEngine;

namespace ArcherAttack
{
    public class Archer : Character
    {
        public Archer(string name, int damage, int hp, int effectTime)
        : base(name, damage, hp, effectTime) { }

        protected override void AttackMethod(Character opponent)
        {
            opponent.TakeDamage(Damage);
            Debug.Log($"Name {opponent.Name} + Health {opponent.HP}");
            Debug.Log($"AttackArcher + {Damage}");
            EffectManager.Instance.StartEffectArcherCoroutine(opponent, Damage * 2, EffectTime);
        }
    }
}
