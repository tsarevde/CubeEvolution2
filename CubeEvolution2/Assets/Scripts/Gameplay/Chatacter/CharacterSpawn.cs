using System;
using UnityEngine;

public class CharacterSpawn : CharacterSelection
{
    public static Action onChangedCharacter;
    [SerializeField] private Transform _spawnPosition;
    
    private void Start()
    {
        onSelectCharacter += ChangeCharacter;
        SpawnCharacter();
    }

    private void OnDisable()
    {
        onSelectCharacter -= ChangeCharacter;
    }

    private void ChangeCharacter()
    {
        DestroyCharacter();
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        Instantiate(_character[SelectionCharacter].Model, _spawnPosition.position, _spawnPosition.rotation, _spawnPosition);
        onChangedCharacter?.Invoke();
    }

    private void DestroyCharacter()
    {
        Destroy(_spawnPosition.GetChild(0).gameObject);
    }
}
