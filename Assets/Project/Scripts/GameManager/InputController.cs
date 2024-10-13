using CharacterInfo;
using Spawn;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Spawner _characterNumber;

    private void Update()
    {
        HandleAttackInput();
    }

    private void HandleAttackInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Character attacker1 = _characterNumber._activeCharacters[0];
            Character attacker2 = _characterNumber._activeCharacters[1];

            if (attacker1 != null && attacker1.CanAttack)
            {
                attacker1.ToAttack(attacker2);
            }

            if (attacker2 != null && attacker2.CanAttack)
            {
                attacker2.ToAttack(attacker1);
            }
        }
    }
}
