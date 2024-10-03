using ArcherAttack;
using CharacterAttack;
using System.Collections.Generic;
using UnityEngine;
using Warrior;
using Wizard;

namespace Spawn
{
    [System.Serializable]
    public class CharacterData
    {
        public string Name;
        public Vector3 SpawnPosition;
        public GameObject Prefab;
        public bool IsActive;
    }

    public class SpawnHero : MonoBehaviour
    {
        [SerializeField] private CharacterData[] _characterData;
        [SerializeField] private WinnerCheck _winner;

        private readonly List<Character> _activeCharacters = new();

        private void Update()
        {
            CheckCharacters(); // пока не придумал еще куда это, идея: каждый выстрел
            HandleAttackInput();
        }

        public List<Character> SpawnCharacters()
        {
            foreach (var data in _characterData)
            {
                SpawnCharacter(data);
            }
            return _activeCharacters;
        }

        private void SpawnCharacter(CharacterData data)
        {
            if (data.IsActive)
            {
                Instantiate(data.Prefab, data.SpawnPosition, Quaternion.identity);
                Character character = CreateCharacterInstance(data.Name);
                _activeCharacters.Add(character);
            }
        }

        private void CheckCharacters()
        {
            _activeCharacters.RemoveAll(character => character.HP <= 0);
            if (_activeCharacters.Count == 1)
            {
                _winner.ShowWinner(_activeCharacters[0].Name);
            }
        }

        private Character CreateCharacterInstance(string type)
        {
            return type switch
            {
                "Wizard" => new WizardAttack("Wizard", 15, 120, 3),
                "Warrior" => new WarriorAttack("Warrior", 20, 150, 5),
                "Archer" => new Archer("Archer", 10, 100, 7),
                _ => null
            };
        }

        private void HandleAttackInput()
        {
            if (Input.GetMouseButtonDown(0) && _activeCharacters.Count == 2)
            {
                Character attacker1 = _activeCharacters[0];
                Character attacker2 = _activeCharacters[1];

                attacker1.AttackMethod(attacker2); 
                attacker2.AttackMethod(attacker1);
            }
        }
    }
}



