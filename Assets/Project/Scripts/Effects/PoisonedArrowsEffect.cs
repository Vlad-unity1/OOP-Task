using CharacterInfo;
using System.Collections;
using UnityEngine;

namespace PoisonedEffectSystem
{
    public class PoisonedArrowsEffect : MonoBehaviour
    {
        public void PoisonedEffect(Character target, int damage, float effectTime, float duration)
        {
            StartCoroutine(Effect(target, damage, effectTime, duration));
        }

        private IEnumerator Effect(Character target, int damage, float effectTime, float duration)
        {
            float interval = 0f;
            while (interval < duration)
            {
                target.TakeDamage(damage / 2);
                yield return new WaitForSeconds(effectTime);
                interval += effectTime;
                Debug.Log("Damage Poisoned");
            }
        }
    }
}