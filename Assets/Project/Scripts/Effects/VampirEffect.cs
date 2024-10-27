using CharacterInfo;
using EffectApply;
using UnityEngine;

namespace VampireEffectSystem
{
    public class VampirEffect : Effect
    {
        [SerializeField] private int _healAmount;

        public override void Apply(Character from, Character to)
        {
            from.RestoreHealth(_healAmount);
        }
    }
}