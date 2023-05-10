using UnityEngine;
using System;

public class CharacterLevel : CharacterList
{
    private int selectedIndex;
    public static Action onExpChanged;
    
    public void ExpGive(int amountExp)
    {
        selectedIndex = CharacterSelection.SelectionCharacter;

        if (amountExp > 0)
            _character[selectedIndex].CurrentExp += amountExp;

        if (_character[selectedIndex].CurrentExp >= _character[selectedIndex].EnoughtExp)
            LevelUP();
        
        onExpChanged?.Invoke();
    }

    private void LevelUP()
    {
        _character[selectedIndex].CurrentExp -= _character[selectedIndex].EnoughtExp;
        _character[selectedIndex].EnoughtExp = Mathf.CeilToInt(_character[selectedIndex].EnoughtExp*1.15f);

        _character[selectedIndex].CurrentLevel += 1;
    }
}
