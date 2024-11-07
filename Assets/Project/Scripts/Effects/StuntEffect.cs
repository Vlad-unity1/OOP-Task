using CharacterInfo;
using EffectApply;
using System.Collections;
using UnityEngine;

namespace StuntEffectSystem
{
    public class StuntEffect : Effect
    {
        [SerializeField] private float _hitChance;

        public override void Apply(Character from, Character to)
        {
            if (Random.value <= _hitChance)
            {
                StartCoroutine(Effect(to));
                Debug.Log(to);
            }
        }

        private IEnumerator Effect(Character target)
        {
            if (!target.IsStunned)
            {
                target.ReloadAttack(false);
                target.SetStunned(true);
                yield return new WaitForSeconds(EffectTime);
                target.SetStunned(false);
                target.ReloadAttack(true);
            }
        }
    }
}