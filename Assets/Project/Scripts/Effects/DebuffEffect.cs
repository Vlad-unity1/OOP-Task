using CharacterInfo;
using EffectApply;
using System.Collections;
using UnityEngine;

namespace DebuffEffectSystem
{
    public class DebuffEffect : Effect
    {
        private readonly int _originalDamage;
        private Coroutine _effect;

        public override void Apply(Character from, Character to)
        {
            _effect = StartCoroutine(Effect(to));
        }

        private IEnumerator Effect(Character target)
        {
            if (_effect != null) 
            {
                yield break;
            }

            target.SetDamage(_originalDamage / 2);
            yield return new WaitForSeconds(EffectTime);
            target.SetDamage(_originalDamage);
            _effect = null;
        }
    }
}