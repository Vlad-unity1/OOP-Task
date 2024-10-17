using CharacterInfo;
using CharacterViewDie;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private CharacterDataObject[] _characterData;
        private FactorySpawner _factorySpawner;
        public List<Character> ActiveCharacters { get; private set; } = new();
        private readonly HashSet<int> _usedIndexes = new();
        private readonly HashSet<Vector3> _usedPositions = new();
        [SerializeField] private Vector3[] spawnPositions = { new(2, 0, -8), new(5, 0, -8) };
        public static Spawner Instance { get; private set; }

        private void Start()
        {
            Instance = this;
            _factorySpawner = gameObject.AddComponent<FactorySpawner>();
            SpawnCharacters();
        }

        public List<Character> SpawnCharacters()
        {
            int totalCharacters = _characterData.Length;

            for (int i = 0; i < 2; i++)
            {
                int randomIndex;

                do
                {
                    randomIndex = Random.Range(0, totalCharacters);
                } while (_usedIndexes.Contains(randomIndex)); 

                _usedIndexes.Add(randomIndex);

                Vector3 spawnPosition = spawnPositions[0];

                if (_usedPositions.Contains(spawnPosition))
                {
                    spawnPosition = spawnPositions[1];
                }

                _usedPositions.Add(spawnPosition); 

                SpawnCharacter(_characterData[randomIndex], spawnPosition);
            }

            return ActiveCharacters;
        }


        private void SpawnCharacter(CharacterDataObject data, Vector3 position)
        {
            GameObject characterObject = Instantiate(data.Prefab, position, Quaternion.identity);
            if (characterObject.TryGetComponent<CharacterView>(out var characterView))
            {
                Character character = _factorySpawner.CreateCharacterInstance(data, characterObject);
                characterView.Initialize(character);
                ActiveCharacters.Add(character);
            }
        }
    }
}
public enum CharacterType
{
    Wizard,
    Warrior,
    Archer,
    Broodmother
}