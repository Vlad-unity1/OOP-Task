using CharacterAttack;
using System.Collections;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

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

    public void StartEffectWarriorCoroutine(Character target, float effectTime)
    {
        StartCoroutine(EffectWarrior(target, effectTime));
    }

    private IEnumerator EffectWarrior(Character target, float effectTime)
    {
        Debug.Log("StuntEffect" + target.Name);
        yield return new WaitForSeconds(effectTime);
        Debug.Log("StuntEffectRemove" + target.Name);
    }

    public void StartEffectWizardCoroutine(Character target, float effectTime)
    {
        Debug.Log("EffectWizard");
        StartCoroutine(EffectWizard(target,effectTime));
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
