using CharacterInfo;
using System.Collections;
using UnityEngine;

namespace DebuffEffectSystem
{
    public class DebuffEffect : MonoBehaviour
    {
        public EffectsType Debuff;
        private bool isDebuffed = false;
        int originalDamage;

        public void EffectDebuff(Character target, float effectTime)
        {
            StartCoroutine(Effect(target, effectTime));
        }

        internal EffectsType GetEffectType()
        {
            return Debuff;
        }

        private IEnumerator Effect(Character target, float effectTime)
        {
            if (!isDebuffed) 
            {
                originalDamage = target.Damage;
                isDebuffed = true; 
            }

            target.SetDamage(originalDamage / 2);
            yield return new WaitForSeconds(effectTime);
            target.SetDamage(originalDamage);
            isDebuffed = false;
        }
    }
}