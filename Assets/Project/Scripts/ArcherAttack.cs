using ApplyAttackEffect;
using CharacterAttack;
using System.Collections;
using UnityEngine;

namespace Archer
{
    public class ArcherAttack : Character, IAttackEffect
    {
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public ArcherAttack() : base("Archer", 5, 200, 3) { }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.TryGetComponent<Character>(out var target))
                    {
                        AttackMethod(target);
                    }
                }
            }
        }

        public void ApplyEffect(Character target)
        {
            print("EffectArcher");
            target.StartCoroutine(RemoveEffectAfterTime(target));
        }

        private IEnumerator RemoveEffectAfterTime(Character target)
        {
            target.HP -= target.Damage * 2;
            yield return new WaitForSeconds(EffectTime);
            print("ArrowEffectRemove");
        }

        protected override void AttackMethod(Character opponent)
        {
            opponent.HP -= Damage;
            print($"Name {opponent.Name} + Health {opponent.HP}");
            print($"AttackArcher + {Damage}");
            ApplyEffect(opponent);
            opponent.DieCheck(this);
        }
    }
}
