using UnityEngine;

public class CharacterHolder : MonoBehaviour
{
    [SerializeField] private Character[] _character;

    void Start()
    {
        Vector3 position = transform.position + new Vector3(0, -1, 0);

        Instantiate(_character[2].Model, position, transform.rotation, this.transform);
        Debug.Log(_character[2].currentExp);
        _character[2].currentExp += 4;
        Debug.Log(_character[2].currentExp);
    }
}
