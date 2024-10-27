using CharacterInfo;
using EffectApply;
using System.Collections;
using UnityEngine;

namespace PoisonedEffectSystem
{
    public class PoisonedArrowsEffect : Effect
    {
        [SerializeField] private float _duration;
        [SerializeField] private int _damage;

        public override void Apply(Character from, Character to)
        {
            StartCoroutine(Effect(to));
        }

        private IEnumerator Effect(Character target)
        {
            float interval = 0f;
            while (interval < _duration)
            {
                target.TakeDamage(_damage / 2, GetType().Name);
                yield return new WaitForSeconds(EffectTime);
                interval += EffectTime;
            }
        }
    }
}