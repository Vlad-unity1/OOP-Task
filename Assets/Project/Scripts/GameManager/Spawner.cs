using CharacterInfo;
using CharacterScriptable;
using CharacterViewDie;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Spawn
{
    public class Spawner : MonoBehaviour
    {
        public List<Character> ActiveCharacters { get; } = new();

        [SerializeField] private CharacterDataObject[] _characterData;
        [SerializeField] private Transform _firstSpawnPoint;
        [SerializeField] private Transform _secondSpawnPoint;

        public void SpawnCharacters()
        {
            CharacterDataObject first = _characterData[Random.Range(0, _characterData.Length)];
            CharacterDataObject[] leftDatas = _characterData
                .Where(x => x != first)
                .ToArray();

            CharacterDataObject second = leftDatas[Random.Range(0, leftDatas.Length)];

            SpawnCharacter(first, _firstSpawnPoint);
            SpawnCharacter(second, _secondSpawnPoint);
        }

        private void SpawnCharacter(CharacterDataObject data, Transform point)
        {
            CharacterView instance = Instantiate(data.Prefab, point.position, Quaternion.identity);
            Character character = new Character(data.Damage, data.Health, data.Type, instance.Effect);
            instance.Initialize(character);
            ActiveCharacters.Add(character);
        }
    }
}