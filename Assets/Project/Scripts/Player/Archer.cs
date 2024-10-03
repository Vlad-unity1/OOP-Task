using CharacterAttack;
using UnityEngine;

namespace ArcherAttack
{
    public class Archer : Character
    {
       private readonly PoisonedArrowsEffect _effectArrow;
        
        public Archer(string name, int damage, int hp, int effectTime)
        : base(name, damage, hp, effectTime) { }

        public override void AttackMethod(Character opponent)
        {
            opponent.TakeDamage(Damage);
            Debug.Log($"Name {opponent.Name} + Health {opponent.HP}");
            Debug.Log($"AttackArcher + {Damage}");
            _effectArrow.StartEffectArcherCoroutine(opponent, Damage * 2, EffectTime); 
        }
    }
}
