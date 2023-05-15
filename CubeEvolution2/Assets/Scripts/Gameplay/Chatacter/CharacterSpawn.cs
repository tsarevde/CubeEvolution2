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
        Debug.Log("Change");

        DestroyCharacter();
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        Debug.Log("Spawn " + SelectionCharacter + " Model: " + _character[SelectionCharacter].Model);
        Instantiate(_character[SelectionCharacter].Model, transform.position, transform.rotation, transform);

        onChangedCharacter?.Invoke();
    }

    private void DestroyCharacter()
    {
        Debug.Log("Kill " + transform.GetChild(0).gameObject);
        Destroy(transform.GetChild(0).gameObject);
    }
}
