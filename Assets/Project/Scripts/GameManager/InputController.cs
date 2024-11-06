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
                Character attacker1 = _spawner.FirstCharacter;
                Character attacker2 = _spawner.SecondCharacter;

                attacker1.Attack(attacker2);
                attacker2.Attack(attacker1);

                yield return new WaitForSeconds(COOLLDOWN);

                attacker1.ReloadAttack(true);
                attacker2.ReloadAttack(true);
            }
        }

        private void OnDisable()
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }
    }
}