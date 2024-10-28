using CharacterInfo;
using Spawn;
using System;
using System.Collections;
using UnityEngine;

namespace InputPlayer
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Spawner _characterNumber;

        private void Start()
        {
            StartAttackCircle();
        }

        private void StartAttackCircle()
        {
            Invoke(nameof(TryAttack), 0f);
        }

        private void TryAttack()
        {
            if (_characterNumber.ActiveCharacters.Count < 2) return;

            Character attacker1 = _characterNumber.ActiveCharacters[0];
            Character attacker2 = _characterNumber.ActiveCharacters[1];

            if (attacker1.CanAttack)
            {
                attacker1.Attack(attacker2);
                attacker1.CanAttack = false;
            }

            if (attacker2.CanAttack)
            {
                attacker2.Attack(attacker1);
                attacker2.CanAttack = false;
            }

            ResetAttack(new Character[] {attacker1, attacker2});

            Invoke(nameof(TryAttack), 3f);
        }

        private void ResetAttack(Character[] attackers)
        {
            foreach (var attacker in attackers)
            {
                attacker.CanAttack = true;
            }
        }
    }
}
