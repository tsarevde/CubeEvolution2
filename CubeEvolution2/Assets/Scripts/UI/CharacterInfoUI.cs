using UnityEngine;
using TMPro;

public class CharacterInfoUI : CharacterList
{
    // Отображение Названия, Описания персонажа в UI
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _desriptionText;

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

        _nameText.SetText(_character[selectedIndex].Name.ToString());
        _desriptionText.SetText(_character[selectedIndex].Description.ToString());
    }
}
