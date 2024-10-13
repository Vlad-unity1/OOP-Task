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
            target.CanAttack = false;
            yield return new WaitForSeconds(effectTime);
            target.CanAttack = true;
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