using System;
using UnityEngine;

public class CharacterSpawn : CharacterSelection
{
    public static Action onChangedCharacter;
    
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
        Instantiate(_character[SelectionCharacter].Model, transform.position, transform.rotation, transform);
        onChangedCharacter?.Invoke();
    }

    private void DestroyCharacter()
    {
        Destroy(transform.GetChild(0).gameObject);
    }
}
