using CharacterInfo;
using Spawn;
using UnityEngine;

namespace InputPlayer
{
    public class InputController : MonoBehaviour
    {
        public const float COLLDOWN = 5f;
        public const int TOTAL_CHARACTERS_IN_MAP = 2;
        [SerializeField] private Spawner _characterNumber;

        public void StartCyclicAttack()
        {
            Invoke(nameof(ExecuteAttack), 0f);
        }

        private void ExecuteAttack()
        {
            if (_characterNumber.ActiveCharacters.Count < TOTAL_CHARACTERS_IN_MAP) return;

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

            ReloadAttack(new Character[] {attacker1, attacker2});

            Invoke(nameof(ExecuteAttack), COLLDOWN);
        }

        private void ReloadAttack(Character[] attackers)
        {
            foreach (var attacker in attackers)
            {
                attacker.CanAttack = true;
            }
        }
    }
}
