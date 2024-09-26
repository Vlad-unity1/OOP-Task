using Spawn;
using System.ComponentModel;
using UnityEngine;

namespace CharacterAttack
{
    public abstract class Character : MonoBehaviour
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int HP { get; set; }
        public int EffectTime { get; set; }
        private WinnerCheck Winner { get; set; }

        private void Start()
        {
            Winner = FindObjectOfType<WinnerCheck>();
        }

        public Character(string name, int damage, int hp, int effectTime)
        {
            Name = name;
            Damage = damage;
            HP = hp;
            EffectTime = effectTime;
        }

        public void DieCheck(Character character)
        {
            if(HP <= 0)
            {
                Destroy(gameObject);
                print($"{Name} has died");
                Winner.ShowWinner(character.Name);
            }
        }

        protected abstract void AttackMethod(Character opponent);
    }
}
