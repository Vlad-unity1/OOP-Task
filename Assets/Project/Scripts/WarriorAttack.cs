using ApplyAttackEffect;
using CharacterAttack;
using System.Collections;
using UnityEngine;

namespace Warrior
{
    public class WarriorAttack : Character, IAttackEffect
    {
        private Camera _mainCamera;
        private Character _selectedTarget;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public WarriorAttack() : base("Warrior", 10, 200, 3) { }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && _selectedTarget != null) 
            {
                AttackMethod(_selectedTarget);  
            }

            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<Character>(out var target))
                {
                    _selectedTarget = target; 
                }
            }
            else
            {
                _selectedTarget = null;
            }
        }

        public void ApplyEffect(Character target)
        {
            target.StartCoroutine(RemoveEffectAfterTime(target));
        }

        private IEnumerator RemoveEffectAfterTime(Character target)
        {
            print("StuntEffect");
            yield return new WaitForSeconds(EffectTime);
            print("StuntEffectRemove");
        }

        protected override void AttackMethod(Character opponent)
        {
            opponent.HP -= Damage;
            print($"Name {opponent.Name} + Health {opponent.HP}");
            print($"AttackWarior + {Damage}");
            Chance(opponent);
            opponent.DieCheck(this);
        }

        private void Chance(Character opponent)
        {
            int randomInt = Random.Range(0, 10);
            if (randomInt >= 8)
            {
                ApplyEffect(opponent);
            }
        }
    }
}
