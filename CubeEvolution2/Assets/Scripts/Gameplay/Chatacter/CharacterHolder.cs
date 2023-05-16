using UnityEngine;

public class CharacterHolder : CharacterSelection
{

    private void Start()
    {
        CreateModel();
    }

    private void CreateModel()
    {
        Instantiate(_character[SelectionCharacter].Model, transform.position + new Vector3(0, -1 , 0), transform.rotation, this.transform);
    }
}
