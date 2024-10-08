using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 51)]
public class CharacterDataObject : ScriptableObject
{
    public CharacterType Type;
    public GameObject Prefab;
    public Vector3 SpawnPosition;
    public int Health;
    public int Damage;
    public int EffectTime;
}
