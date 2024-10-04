using CharacterInfo;
using System.Collections;
using UnityEngine;

namespace PoisonedEffectSystem
{
    public class PoisonedArrowsEffect : MonoBehaviour
    {
        public void StartEffectArcherCoroutine(Character target, int damage, float effectTime)
        {
            StartCoroutine(RemoveEffectArcherAfterTime(target, damage, effectTime));
        }

        private IEnumerator RemoveEffectArcherAfterTime(Character target, int damage, float effectTime)
        {
            target.TakeDamage(damage);
            yield return new WaitForSeconds(effectTime);
            Debug.Log("Effect removed after time." + target.Name);
        }
    }
}