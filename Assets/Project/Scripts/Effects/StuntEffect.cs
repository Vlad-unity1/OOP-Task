﻿using CharacterInfo;
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
            }
        }

        private IEnumerator Effect(Character target)
        {
            target.CanAttack = false;
            target.IsStunned = true;
            yield return new WaitForSeconds(EffectTime);
            target.CanAttack = true;
            target.IsStunned = false;
        }
    }
}