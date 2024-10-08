﻿using CharactersArcher;
using CharacterInfo;
using System.Collections.Generic;
using UnityEngine;
using WinnerWindowUI;
using CharacterViewDie;
using DebuffEffectSystem;
using PoisonedEffectSystem;
using StuntEffectSystem;

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

    public class Spawner : MonoBehaviour
    {
        [SerializeField] private CharacterData[] _characterData;
        [SerializeField] private WinnerCheckUI _winner;

        private readonly List<Character> _activeCharacters = new();

        private void Start()
        {
            SpawnCharacters(); 
        }

        private void Update()
        {
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
                GameObject characterObject = Instantiate(data.Prefab, data.SpawnPosition, Quaternion.identity);               
                if (characterObject.TryGetComponent<CharacterView>(out var characterView))
                {
                    Character character = CreateCharacterInstance(data.Name);
                    characterView.Initialize(character);
                    _activeCharacters.Add(character);
                }
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
                "Wizard" => new CharacterWizard.Wizard("Wizard", 15, 120, 3, gameObject.AddComponent<DebuffEffect>()),
                "Warrior" => new CharacterWarrior.Warrior("Warrior", 30, 150, 5, gameObject.AddComponent<StuntEffect>()),
                "Archer" => new Archer("Archer", 10, 100, 7, gameObject.AddComponent<PoisonedArrowsEffect>()),
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
                CheckCharacters();
            }
        }
    }
}



