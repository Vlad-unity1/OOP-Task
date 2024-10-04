using System;
using UnityEngine;

namespace CharacterInfo
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int HP { get; private set; }
        public int EffectTime { get; private set; }
        public event Action<Character> OnDeath;

        public Character(string name, int damage, int hp, int effectTime)
        {
            Name = name;
            Damage = damage;
            HP = hp;
            EffectTime = effectTime;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            HP = Mathf.Max(HP, 0);
            if (HP <= 0)
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
            OnDeath?.Invoke(this);
        }

        public abstract void AttackMethod(Character opponent);
    }
}