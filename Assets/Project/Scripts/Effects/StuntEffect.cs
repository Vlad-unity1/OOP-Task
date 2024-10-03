using CharacterAttack;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StuntEffect : MonoBehaviour
{
    public void StartEffectWarriorCoroutine(Character target, float effectTime)
    {
        Chance(target, effectTime);
    }

    private IEnumerator EffectWarrior(Character target, float effectTime)
    {
        Debug.Log("StuntEffect" + target.Name);
        yield return new WaitForSeconds(effectTime);
        Debug.Log("StuntEffectRemove" + target.Name);
    }

    private void Chance(Character target, float effectTime)
    {
        int randomInt = Random.Range(0, 10);
        if (randomInt >= 8)
        {
            StartCoroutine(EffectWarrior(target, effectTime));
        }
    }
}
