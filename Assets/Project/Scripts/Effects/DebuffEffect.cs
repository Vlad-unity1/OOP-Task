using CharacterInfo;
using System.Collections;
using UnityEngine;

namespace DebuffEffectSystem
{
    public class DebuffEffect : MonoBehaviour
    {
        public void StartEffectWizardCoroutine(Character target, float effectTime)
        {
            Debug.Log("EffectWizard");
            StartCoroutine(EffectWizard(target, effectTime));
        }

        private IEnumerator EffectWizard(Character target, float effectTime)
        {
            int originalDamage = target.Damage;

            target.SetDamage(originalDamage / 2);
            yield return new WaitForSeconds(effectTime);
            target.SetDamage(originalDamage);
            Debug.Log("WizardEffectRemove");
        }
    }
}