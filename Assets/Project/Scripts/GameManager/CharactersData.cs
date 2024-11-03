using CharacterSystemView;
using UnityEngine;
using CharacterTypes;

namespace CharacterScriptable
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 51)]
    public class CharacterData : ScriptableObject
    {
        public CharacterType Type;
        public CharacterView Prefab;
        public int Health;
        public int Damage;
    }
}
