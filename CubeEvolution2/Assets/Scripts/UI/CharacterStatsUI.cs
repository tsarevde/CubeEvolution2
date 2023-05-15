using UnityEngine;
using TMPro;

public class CharacterStatsUI : CharacterSelection
{
    // Отображение статистик(здоровье, урон, скорость) персонажа в UI
    [SerializeField] private TextMeshProUGUI[] _amountText;

    private void Start()
    {
        CharacterSpawn.onChangedCharacter += UpdateText;
        UpdateText();
    }

    private void OnDisable()
    {
        CharacterSpawn.onChangedCharacter -= UpdateText;
    }

    private void UpdateText()
    {
        _amountText[0].SetText(_character[SelectionCharacter].Health.ToString());
        _amountText[1].SetText(_character[SelectionCharacter].Damage.ToString());
        _amountText[2].SetText(_character[SelectionCharacter].Speed.ToString());
    }
}
