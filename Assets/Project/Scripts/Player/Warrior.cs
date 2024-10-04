using CharacterInfo;
using StuntEffectSystem;
using UnityEngine;

namespace CharacterWarrior
{
    public class Warrior : Character
    {
        private readonly StuntEffect _effectStunt;

        public Warrior(string name, int damage, int hp, int effectTime, StuntEffect stuntEffect)
        : base(name, damage, hp, effectTime) 
        { 
            _effectStunt = stuntEffect;
        }

        public override void AttackMethod(Character opponent)
        {
            opponent.TakeDamage(Damage);
            Debug.Log($"Name {opponent.Name} + Health {opponent.HP}");
            Debug.Log($"AttackWarior + {Damage}");
            _effectStunt.StartEffectWarriorCoroutine(opponent, EffectTime);
        }
    }
}
