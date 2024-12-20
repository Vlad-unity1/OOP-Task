﻿using CharacterTypes;
using EffectApply;
using System;
using UnityEngine;

namespace CharacterInfo
{
    public class Character
    {
        public event Action<string> OnEffectApply;
        public event Action OnHealthChanged;
        public event Action OnDeath;

        public int Damage { get; private set; }
        public int HP { get; private set; }
        public int CurrentHp { get; private set; }
        public CharacterType Type { get; private set; }
        public bool IsAlive { get; private set; }
        public bool CanAttack { get; private set; }
        public bool IsStunned { get; private set; }
        public Effect Effect { get; private set; }

        public Character(int damage, int hp, CharacterType type, Effect effect)
        {
            Damage = damage;
            HP = hp;
            Type = type;
            IsAlive = true;
            CurrentHp = hp;
            CanAttack = true;
            Effect = effect;
            IsStunned = false;
        }

        public void TakeDamage(int damage, string effect)
        {
            CurrentHp = Mathf.Max(CurrentHp - damage, 0);

            OnHealthChanged?.Invoke();
            OnEffectApply?.Invoke(effect);

            if (CurrentHp == 0)
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
            CurrentHp += currentHealh;

            if (CurrentHp > HP)
            {
                CurrentHp = HP;
            }
        }

        public bool ReloadAttack(bool canAttack)
        {
            CanAttack = canAttack;
            return CanAttack;
        }

        public void SetStunned(bool isStunned)
        {
            IsStunned = isStunned;
        }

        private void Die()
        {
            IsAlive = false;
            OnDeath?.Invoke();
        }

        public void Attack(Character opponent)
        {
            if (!IsStunned && opponent.IsAlive && CanAttack)
            {
                opponent.TakeDamage(Damage, Effect.GetType().Name);
                Effect.Apply(this, opponent);
                CanAttack = false;
            }
        }
    }
}