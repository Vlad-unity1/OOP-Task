using CharacterInfo;
using CharacterScriptable;
using CharacterViewDie;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class Spawner : MonoBehaviour
    {
        public const int CharactersInScene = 2;
        public List<Character> ActiveCharacters { get; private set; } = new();
        [SerializeField] private CharacterDataObject[] _characterData;
        [SerializeField] private Vector3[] _spawnPositions = { new(2, 0, -8), new(5, 0, -8) };
        private readonly HashSet<int> _usedIndexes = new();
        private readonly HashSet<Vector3> _usedPositions = new();

        public void SpawnCharacters()
        {
            int totalCharacters = _characterData.Length;
            for (int i = 0; i < CharactersInScene; i++)
            {
                int randomIndex;

                do
                {
                    randomIndex = Random.Range(0, totalCharacters);
                } while (_usedIndexes.Contains(randomIndex));

                _usedIndexes.Add(randomIndex);

                Vector3 spawnPosition = _spawnPositions[0];

                if (_usedPositions.Contains(spawnPosition))
                {
                    spawnPosition = _spawnPositions[1];
                }

                _usedPositions.Add(spawnPosition);

                SpawnCharacter(_characterData[randomIndex], spawnPosition);
            }
        }

        private void SpawnCharacter(CharacterDataObject data, Vector3 position)
        {
            if(ActiveCharacters.Count < CharactersInScene)
            {
                CharacterView instance = Instantiate(data.Prefab, position, Quaternion.identity);
                Character character = new(data.Damage, data.Health, data.Type, instance.Effect);
                instance.Initialize(character);
                ActiveCharacters.Add(character);
            }
        }
    }
}