using UnityEngine;
using System;

public class CharacterLevel : CharacterSelection
{
    public static Action onExpChanged;
    
    public void ExpGive(int amountExp)
    {

        if (amountExp > 0)
            _character[SelectionCharacter].CurrentExp += amountExp;

        if (_character[SelectionCharacter].CurrentExp >= _character[SelectionCharacter].EnoughtExp)
            LevelUP();
        
        onExpChanged?.Invoke();
    }

    private void LevelUP()
    {
        _character[SelectionCharacter].CurrentExp -= _character[SelectionCharacter].EnoughtExp;
        _character[SelectionCharacter].EnoughtExp = Mathf.CeilToInt(_character[SelectionCharacter].EnoughtExp*1.15f);

        _character[SelectionCharacter].CurrentLevel += 1;
    }
}
