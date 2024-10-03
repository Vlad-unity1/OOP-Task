﻿using CharacterAttack;
using UnityEngine;

namespace Warrior
{
    public class WarriorAttack : Character
    {
        private readonly StuntEffect _effectStunt;

        public WarriorAttack(string name, int damage, int hp, int effectTime, StuntEffect stuntEffect)
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
