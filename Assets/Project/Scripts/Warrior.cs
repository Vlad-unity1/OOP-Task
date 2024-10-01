using CharacterAttack;
using UnityEngine;

namespace Warrior
{
    public class WarriorAttack : Character
    {
        public WarriorAttack(string name, int damage, int hp, int effectTime)
        : base(name, damage, hp, effectTime) { }

        protected override void AttackMethod(Character opponent)
        {
            opponent.TakeDamage(Damage);
            Debug.Log($"Name {opponent.Name} + Health {opponent.HP}");
            Debug.Log($"AttackWarior + {Damage}");
            Chance(opponent); // вот тут возможно я мог сделать как то иначе.. 
        }

        private void Chance(Character opponent)
        {
            int randomInt = Random.Range(0, 10);
            if (randomInt >= 8)
            {
                EffectManager.Instance.StartEffectWarriorCoroutine(opponent, EffectTime);
            }
        }
    }
}
