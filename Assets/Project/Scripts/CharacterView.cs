using CharacterAttack;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private Character _character;

    public void Initialize(Character character)
    {
        this._character = character;
    }

    public void Die(Character character)
    {
        if(character.HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
