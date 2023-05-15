using System;

public class CharacterSelection : CharacterList
{
    public static int SelectionCharacter { get; private set; } = 0;
    protected static Action onSelectCharacter;

    private void NextCharacter()
    {
        if (SelectionCharacter < _character.Length - 1)
            SelectionCharacter++;
        else SelectionCharacter = 0;

        onSelectCharacter?.Invoke();
    }

    private void PreviousCharacter()
    {
        if (SelectionCharacter <= 0)
            SelectionCharacter = _character.Length - 1;
        else SelectionCharacter--;

        onSelectCharacter?.Invoke();
    }
}
