using UnityEngine;
using TMPro;

public class CharacterStatsUI : CharacterList
{
    // Отображение статистик(здоровье, урон, скорость) персонажа в UI
    [SerializeField] private TextMeshProUGUI[] _amountText;

    private void Start()
    {
        CharacterSelection.onChangedCharacter += UpdateText;
        UpdateText();
    }

    private void OnDisable()
    {
        CharacterSelection.onChangedCharacter -= UpdateText;
    }

    private void UpdateText()
    {
        int selectedIndex = CharacterSelection.SelectionCharacter;

        _amountText[0].SetText(_character[selectedIndex].Health.ToString());
        _amountText[1].SetText(_character[selectedIndex].Damage.ToString());
        _amountText[2].SetText(_character[selectedIndex].Speed.ToString());
    }
}
