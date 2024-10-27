using CharacterViewDie;
using UnityEngine;
using CharacterTypes;

namespace CharacterScriptable
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 51)]
    public class CharacterDataObject : ScriptableObject
    {
        public CharacterType Type;
        public CharacterView Prefab;
        public int Health;
        public int Damage;
    }
}
