using ArcherAttack;
using CharacterAttack;
using CharacterFactoryI;
using UnityEngine;
using Warrior;
using Wizard;

public class CharacterFactory : MonoBehaviour, ICharacterFactory
{
    [SerializeField] private GameObject[] _characterPrefabs;

    public Character CreateCharacter(string type, Vector3 position)
    {
        GameObject prefab = GetCharacterPrefab(type);
        GameObject characterObject = Object.Instantiate(prefab, position, Quaternion.identity);

        Character character = CreateCharacterInstance(type);
        if (characterObject.TryGetComponent<CharacterView>(out var characterView))
        {
            characterView.Initialize(character);
        }

        return character;
    }

    private Character CreateCharacterInstance(string type)
    {
        switch (type)
        {
            case "Wizard":
                return new WizardAttack("Wizard", 15, 120, 3);
            case "Warrior":
                return new WarriorAttack("Warrior", 15, 120, 3);
            case "Archer":
                return new Archer("Archer", 15, 120, 3);
            default:
                return null;
        }
    }

    private GameObject GetCharacterPrefab(string type)
    {
        switch (type)
        {
            case "Wizard":
                return _characterPrefabs[0];
            case "Warrior":
                return _characterPrefabs[1];
            case "Archer":
                return _characterPrefabs[2];
            default:
                return null;
        }
    }
}