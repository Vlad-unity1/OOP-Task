using CharacterAttack;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class SpawnHero : MonoBehaviour
    {
        [SerializeField] private Vector3 _spawnPositionWizard;
        [SerializeField] private Vector3 _spawnPositionWarrior;
        [SerializeField] private Vector3 _spawnPositionArcher;
        [SerializeField] private CharacterFactory _characterFactory;
        private List<Character> _activeCharacters = new();

        private void Start()
        {
            SpawnObject();
        }

        private void Update()
        {
            CheckCharacters(); // возможно это не правильно проверять такие вещи в апдейт, если придумаю что то, изменю
        }

        private void SpawnObject()
        {
            Character wizard = _characterFactory.CreateCharacter("Wizard", _spawnPositionWizard);
            Character warrior = _characterFactory.CreateCharacter("Warrior", _spawnPositionWarrior);
            Character archer = _characterFactory.CreateCharacter("Archer", _spawnPositionArcher);

            _activeCharacters.Add(wizard);
            _activeCharacters.Add(warrior);
            _activeCharacters.Add(archer);
        }

        private void CheckCharacters()
        {
            _activeCharacters.RemoveAll(character => character.HP <= 0);
            if( _activeCharacters.Count == 1 )
            {
                Debug.Log($"Победитель: {_activeCharacters[0].Name}");
            }
        }
    }
}

