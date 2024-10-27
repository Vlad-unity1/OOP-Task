using CharacterInfo;
using UnityEngine;

namespace EffectApply
{
    public abstract class Effect : MonoBehaviour
    {
        [SerializeField] protected float EffectTime;

        public abstract void Apply(Character from, Character to);
    }
}
