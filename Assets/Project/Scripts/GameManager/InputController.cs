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

            attacker1.ToAttack(attacker2);
            attacker2.ToAttack(attacker1);
        }
    }
}
