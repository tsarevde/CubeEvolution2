using UnityEngine;
using TMPro;
using System;

public class CharacterInfoUI : CharacterList
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _desriptionText;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _speedText;

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
        _healthText.SetText(_character[selectedIndex].Health.ToString());
        _damageText.SetText(_character[selectedIndex].Damage.ToString());
        _speedText.SetText(_character[selectedIndex].Speed.ToString());
    }
}
