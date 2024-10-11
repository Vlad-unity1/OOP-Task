using System;
using UnityEngine;

namespace CharacterInfo
{
    public abstract class Character
    {
        public int Damage { get; private set; }
        public int HP { get; private set; }
        public int EffectTime { get; private set; }
        public CharacterType Type { get; internal set; }
        public bool IsAlive { get; internal set; }

        public event Action<Character> OnDeath;

        public Character(int damage, int hp, int effectTime, CharacterType type)
        {
            Damage = damage;
            HP = hp;
            EffectTime = effectTime;
            Type = type;
            IsAlive = true;
        }

        public void TakeDamage(int damage)
        {
            HP = Mathf.Max(HP - damage, 0);
            if (HP == 0)
            {
                Die();
            }
        }

        public void SetDamage(int newDamage)
        {
            Damage = newDamage;
        }
        
        public void Die()
        {
            IsAlive = false;
            OnDeath?.Invoke(this);
        }

        public abstract void ToAttack(Character opponent);
    }
}