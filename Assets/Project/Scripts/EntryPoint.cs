using CharacterAttack;
using Spawn;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private List<Character> _characters = new();
    [SerializeField] private SpawnHero _charactersSpawner;

    private void Start()
    {
       _characters = _charactersSpawner.SpawnCharacters();
        foreach (Character character in _characters)
        {
            //character.Init(); // еще не дописал скрипт
        }
    }
}
