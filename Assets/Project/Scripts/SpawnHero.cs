using CharacterAttack;
using UnityEngine;
using TMPro;

namespace Spawn
{
    public class SpawnHero : MonoBehaviour
    {
        [SerializeField] private GameObject[] _objectToSpawn;
        [SerializeField] private Vector3 _spawnPositionFirst;
        [SerializeField] private Vector3 _spawnPositionSecond;

        private void Start()
        {
            SpawnObject();
        }

        private void SpawnObject()
        {
            Instantiate(_objectToSpawn[0], _spawnPositionFirst, Quaternion.identity);
            Instantiate(_objectToSpawn[1], _spawnPositionSecond, Quaternion.identity);
        }
    }
}

