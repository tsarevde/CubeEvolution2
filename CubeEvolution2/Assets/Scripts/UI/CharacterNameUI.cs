using UnityEngine;
using TMPro;

public class CharacterNameUI : CharacterSelection
{
    [SerializeField] private TextMeshProUGUI _nameText;

    private void OnEnable()
    {
        if (!_nameText) _nameText = GetComponent<TextMeshProUGUI>();
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
    }
}
