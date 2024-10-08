using CharacterInfo;
using StuntEffectSystem;
using UnityEngine;

namespace CharacterWarrior
{
    public class Warrior : Character
    {
        private readonly StuntEffect _effectStunt;

        public Warrior(int damage, int hp, int effectTime, StuntEffect stuntEffect)
        : base(damage, hp, effectTime, CharacterType.Warrior) 
        { 
            _effectStunt = stuntEffect;
        }

        public override void ToAttack(Character opponent)
        {
            opponent.TakeDamage(Damage);
            _effectStunt.EffectStunt(opponent, EffectTime);
        }
    }
}
