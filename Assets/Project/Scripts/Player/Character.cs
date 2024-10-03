using UnityEngine;

namespace CharacterAttack
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int HP { get; private set; }
        public int EffectTime { get; private set; }

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
        }

        public void SetDamage(int newDamage)
        {
            Damage = newDamage;
        }

        public abstract void AttackMethod(Character opponent);
    }
}