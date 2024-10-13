using CharacterInfo;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VampirEffect : MonoBehaviour
{
    public EffectsType Vampir;

    internal EffectsType GetEffectType()
    {
        return Vampir;
    }
}
