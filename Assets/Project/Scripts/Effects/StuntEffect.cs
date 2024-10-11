using CharacterInfo;
using System.Collections;
using UnityEngine;

namespace StuntEffectSystem
{
    public class StuntEffect : MonoBehaviour
    {
        public EffectsType Stunt;
        public void EffectStunt(Character target, float effectTime)
        {
            Chance(target, effectTime);
        }

        private IEnumerator Effect(Character target, float effectTime)
        {
            Debug.Log("StuntEffect" + target);
            yield return new WaitForSeconds(effectTime);
            Debug.Log("StuntEffectRemove" + target);
        }

        private void Chance(Character target, float effectTime)
        {
            int randomInt = Random.Range(0, 10);
            if (randomInt >= 8)
            {
                StartCoroutine(Effect(target, effectTime));
            }
        }

        internal EffectsType GetEffectType()
        {
            return Stunt;
        }
    }
}