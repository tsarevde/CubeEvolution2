using System;

public class CharacterSelection : CharacterList
{
    public static int SelectionCharacter { get; private set; } = 0;
    public static Action onChangedCharacter;

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

        DestroyCharacter();
        SpawnCharacter(SelectionCharacter);
    }

    private void SpawnCharacter(int selectedIndex)
    {
        Instantiate(_character[selectedIndex].Model, transform.position, transform.rotation, this.transform);
        onChangedCharacter?.Invoke();
    }
    private void DestroyCharacter()
    {
        Destroy(this.transform.GetChild(0).gameObject);
    }

}
