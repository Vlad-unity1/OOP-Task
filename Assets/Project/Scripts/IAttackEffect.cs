using CharacterAttack;
using UnityEngine;

namespace CharacterFactoryI
{
    public interface ICharacterFactory
    {
        Character CreateCharacter(string type, Vector3 position);
    }
}
