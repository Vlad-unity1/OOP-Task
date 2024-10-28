using CharacterInfo;
using UnityEngine;

namespace EffectApply
{
    public abstract class Effect : MonoBehaviour
    {
        [field:SerializeField] public float EffectTime {  get; private set; }

        public abstract void Apply(Character from, Character to);
    }
}
