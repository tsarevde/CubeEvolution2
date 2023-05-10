using UnityEngine;

public class CharacterHolder : CharacterList
{
    void Start()
    {
        Instantiate(_character[2].Model, transform.position, transform.rotation, this.transform);
    }
}
