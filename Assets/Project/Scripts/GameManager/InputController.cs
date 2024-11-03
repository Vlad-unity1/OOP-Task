using CharacterInfo;
using Spawn;
using System.Collections;
using UnityEngine;

namespace InputPlayer
{
    public class InputController : MonoBehaviour
    {
        private const float COOLLDOWN = 5f;

        private Spawner _spawner;
        private Coroutine _attackCoroutine;

        public void Initialize(Spawner spawner)
        {
            _spawner = spawner;
        }

        public void StartCyclicAttack()
        {
            _attackCoroutine = StartCoroutine(ExecuteAttack());
        }

        private IEnumerator ExecuteAttack()
        {
            while (true)
            {
                Character attacker1 = _spawner.ActiveCharacters[0];
                Character attacker2 = _spawner.ActiveCharacters[1];

                attacker1.Attack(attacker2);
                attacker2.Attack(attacker1);

                yield return new WaitForSeconds(COOLLDOWN);

                attacker1.CanAttack = true;
                attacker2.CanAttack = true;
            }
        }

        private void OnDisable()
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }
    }
}