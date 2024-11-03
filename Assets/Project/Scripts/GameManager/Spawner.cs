using CharacterInfo;
using CharacterScriptable;
using CharacterSystemView;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Spawn
{
    public class Spawner : MonoBehaviour
    {
        public List<Character> ActiveCharacters { get; } = new();

        [SerializeField] private CharacterData[] _characterData;
        [SerializeField] private Transform _firstSpawnPoint;
        [SerializeField] private Transform _secondSpawnPoint;

        public void SpawnCharacters()
        {
            CharacterData first = _characterData[Random.Range(0, _characterData.Length)];
            CharacterData[] leftDatas = _characterData
                .Where(x => x != first)
                .ToArray();

            CharacterData second = leftDatas[Random.Range(0, leftDatas.Length)];

            SpawnCharacter(first, _firstSpawnPoint);
            SpawnCharacter(second, _secondSpawnPoint);
        }

        private void SpawnCharacter(CharacterData data, Transform point)
        {
            CharacterView instance = Instantiate(data.Prefab, point.position, Quaternion.identity);
            Character character = new(data.Damage, data.Health, data.Type, instance.Effect);
            instance.Initialize(character);
            ActiveCharacters.Add(character);
        }
    }
}