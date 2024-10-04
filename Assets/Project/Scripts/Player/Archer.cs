using CharacterInfo;
using PoisonedEffectSystem;
using UnityEngine;

namespace CharactersArcher
{
    public class Archer : Character
    {
       private readonly PoisonedArrowsEffect _effectArrow;
        
        public Archer(string name, int damage, int hp, int effectTime, PoisonedArrowsEffect effectArrow)
        : base(name, damage, hp, effectTime) 
        { 
            _effectArrow = effectArrow;
        }
   
        public override void AttackMethod(Character opponent)
        {
            opponent.TakeDamage(Damage);
            Debug.Log($"Name {opponent.Name} + Health {opponent.HP}");
            Debug.Log($"AttackArcher + {Damage}");
            _effectArrow.StartEffectArcherCoroutine(opponent, Damage * 2, EffectTime); 
        }
    }
}
