using CharacterAttack;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private Character _character;

    public void Initialize(Character character)
    {
        this._character = character;
    }
}
