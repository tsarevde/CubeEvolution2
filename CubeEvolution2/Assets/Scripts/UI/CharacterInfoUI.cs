using UnityEngine;
using TMPro;

public class CharacterInfoUI : CharacterSelection
{
    // Отображение Названия, Описания персонажа в UI
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _desriptionText;

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
        _nameText.SetText(_character[SelectionCharacter].Name.ToString());
        _desriptionText.SetText(_character[SelectionCharacter].Description.ToString());
    }
}
