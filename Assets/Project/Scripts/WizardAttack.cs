using ApplyAttackEffect;
using CharacterAttack;
using System.Collections;
using UnityEngine;

namespace Wizard
{
    public class WizardAttack : Character, IAttackEffect
    {
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public WizardAttack() : base("Wizard", 15, 100, 3) { }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
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
            print("EffectWizard");
            target.StartCoroutine(RemoveEffectAfterTime(target));
        }

        private IEnumerator RemoveEffectAfterTime(Character target)
        {
            int originalDamage = target.Damage;

            target.Damage = originalDamage / 2;
            yield return new WaitForSeconds(EffectTime);
            target.Damage = originalDamage;
            print("WizardEffectRemove");
        }

        protected override void AttackMethod(Character opponent)
        {
            opponent.HP -= Damage;
            print($"Name {opponent.Name} + Health {opponent.HP}");
            print($"AttackWizard + {Damage}");
            ApplyEffect(opponent);
            opponent.DieCheck(this);
        }
    }
}
