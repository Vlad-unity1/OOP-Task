using CharacterInfo;
using Spawn;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace InputPlayer
{
    public class InputController : MonoBehaviour
    {
        private const float COOLDOWN = 1f;

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

                if (!attacker1.IsStunned && attacker1.IsAlive)
                {
                    attacker1.Attack(attacker2);
                }

                if (!attacker2.IsStunned && attacker2.IsAlive)
                {
                    attacker2.Attack(attacker1);
                }

                yield return new WaitForSeconds(COOLDOWN);

                if (!attacker1.IsStunned)
                {
                    Debug.Log(attacker1.IsStunned);
                    attacker1.ReloadAttack(true);
                }

                if (!attacker2.IsStunned)
                {
                    Debug.Log(attacker1.IsStunned);
                    attacker2.ReloadAttack(true);
                }
            }
        }

        private void OnDisable()
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }
    }
}