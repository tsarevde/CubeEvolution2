using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private Character[] _character;
    public int SelectionCharacter { get; private set; } = 0;

    void Start()
    {
        SpawnCharacter(SelectionCharacter);
    }

    public void NextCharacter()
    {
        if (SelectionCharacter < _character.Length - 1)
            SelectionCharacter++;
        else SelectionCharacter = 0;

        DestroyCharacter();
        SpawnCharacter(SelectionCharacter);
    }

    public void PreviousCharacter()
    {
        if (SelectionCharacter <= 0)
            SelectionCharacter = _character.Length - 1;
        else SelectionCharacter--;

        SpawnCharacter(SelectionCharacter);
        DestroyCharacter();
    }

    private void SpawnCharacter(int number)
    {
        Instantiate(_character[number].Model, transform.position, transform.rotation, this.transform);
    }
    private void DestroyCharacter()
    {
        Destroy(this.transform.GetChild(0).gameObject);
    }

}
