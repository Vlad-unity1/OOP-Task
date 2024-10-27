using CharacterInfo;
using Spawn;
using System.Collections;
using UnityEngine;

namespace InputPlayer
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Spawner _characterNumber;

        private void Update()
        {
            if (_characterNumber != null)
            StartCoroutine(AttackCoroutine());
        }

        private IEnumerator AttackCoroutine()
        {
            while (true)
            {
                Character attacker1 = _characterNumber.ActiveCharacters[0];
                Character attacker2 = _characterNumber.ActiveCharacters[1];

                if (attacker1 is { CanAttack: true })
                {
                    StartCoroutine(AttackWithCooldown(attacker1, attacker2));
                }

                if (attacker2 is { CanAttack: true })
                {
                    StartCoroutine(AttackWithCooldown(attacker2, attacker1));
                }

                yield return null;
            }
        }

        private IEnumerator AttackWithCooldown(Character attacker, Character target)
        {
            attacker.Attack(target);
            attacker.CanAttack = false;
            yield return new WaitForSeconds(3f);
            attacker.CanAttack = true;
        }
    }
}
