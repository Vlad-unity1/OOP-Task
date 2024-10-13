using CharacterInfo;
using Spawn;
using System.Collections;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Spawner _characterNumber;

    private void Update()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            Character attacker1 = _characterNumber.ActiveCharacters[0];
            Character attacker2 = _characterNumber.ActiveCharacters[1];

            if (attacker1 != null && attacker1.CanAttack)
            {
                StartCoroutine(AttackWithCooldown(attacker1, attacker2));
            }

            if (attacker2 != null && attacker2.CanAttack)
            {
                StartCoroutine(AttackWithCooldown(attacker2, attacker1));
            }

            yield return null; 
        }
    }

    private IEnumerator AttackWithCooldown(Character attacker, Character target)
    {
        attacker.ToAttack(target); 
        attacker.CanAttack = false; 
        yield return new WaitForSeconds(3f); 
        attacker.CanAttack = true; 
    }
}
