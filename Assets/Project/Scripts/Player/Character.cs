using CharacterTypes;
using EffectApply;
using System;
using UnityEngine;

namespace CharacterInfo
{
    public class Character
    {
        private readonly Effect _effect;
        public int Damage { get; private set; }
        public int HP { get; protected set; }
        public int CurrentHP { get; set; }
        public int EffectTime { get; private set; }
        public CharacterType Type { get; internal set; }
        public bool IsAlive { get; internal set; }
        public bool CanAttack {  get; internal set; }

        public event Action<string> OnEffectApply;
        public event Action<int> OnHealthChanged;
        public event Action<Character> OnDeath;

        public Character(int damage, int hp, CharacterType type, Effect effect)
        {
            Damage = damage;
            HP = hp;
            Type = type;
            IsAlive = true;
            CurrentHP = hp;
            CanAttack = true;
            _effect = effect;
        }

        public void TakeDamage(int damage, string effect)
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

            if (CurrentHP > HP)
            {
                CurrentHP = HP;
            }
        }

        private void Die()
        {
            IsAlive = false;
            OnDeath?.Invoke(this);
        }

        public void Attack(Character opponent)
        {
            if (opponent.IsAlive)
            {
                opponent.TakeDamage(Damage,_effect.GetType().Name);
                _effect.Apply(this, opponent);
            }
        }
    }
}