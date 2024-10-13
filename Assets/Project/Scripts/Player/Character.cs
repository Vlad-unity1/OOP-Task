using System;
using UnityEngine;

namespace CharacterInfo
{
    public abstract class Character
    {
        public int Damage { get; private set; }
        public int HP { get; protected set; }
        public int CurrentHP { get; set; }
        public int EffectTime { get; private set; }
        public CharacterType Type { get; internal set; }
        public bool IsAlive { get; internal set; }
        public bool CanAttack {  get; internal set; }

        public event Action<EffectsType> OnEffectApply;
        public event Action<int> OnHealthChanged;
        public event Action<Character> OnDeath;

        public Character(int damage, int hp, int effectTime, CharacterType type)
        {
            Damage = damage;
            HP = hp;
            EffectTime = effectTime;
            Type = type;
            IsAlive = true;
            CurrentHP = hp;
            CanAttack = true;
        }

        public void TakeDamage(int damage, EffectsType effect)
        {
            CurrentHP = Mathf.Max(CurrentHP - damage, 0);
            OnHealthChanged?.Invoke(CurrentHP);
            OnEffectApply?.Invoke(effect);
            if (CurrentHP == 0)
            {
                Die();
                CanAttack = false;
            }
        }

        public void SetDamage(int newDamage)
        {
            Damage = newDamage;
        }

        public void RestoreHealth(int currentHealh)
        {
            CurrentHP += currentHealh;
        }

        private void Die()
        {
            IsAlive = false;
            OnDeath?.Invoke(this);
        }

        public abstract void ToAttack(Character opponent);

        internal void TakeDamage(int damage, object value)
        {
            throw new NotImplementedException();
        }
    }
}