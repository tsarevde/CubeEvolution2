using UnityEngine;

public class CharacterHolder : CharacterList
{

    private void Start()
    {
        CreateModel();
    }

    private void CreateModel()
    {
        Instantiate(_character[CharacterSelection.SelectionCharacter].Model, transform.position + new Vector3(0, -1 , 0), transform.rotation, this.transform);
    }
}
