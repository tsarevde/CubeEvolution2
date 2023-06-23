using UnityEngine;
using TMPro;

public class CharacterDescriptionUI : CharacterSelection
{
    [SerializeField] private TextMeshProUGUI _desriptionText;

    private void OnEnable()
    {
        if (!_desriptionText)  _desriptionText = GetComponent<TextMeshProUGUI>();
        CharacterSpawn.onChangedCharacter += UpdateText;
        UpdateText();
    }

    private void OnDisable()
    {
        CharacterSpawn.onChangedCharacter -= UpdateText;
    }

    private void UpdateText()
    {
        _desriptionText.SetText(_character[SelectionCharacter].Description.ToString());
    }
}
