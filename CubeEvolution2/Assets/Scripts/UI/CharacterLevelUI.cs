using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterLevelUI : CharacterSelection
{
    // Отображение уровня игрока в UI
    [SerializeField] private Image _cubeExp;
    [SerializeField] private TextMeshProUGUI _textCubeExp;
    [SerializeField] private TextMeshProUGUI _textCubeLevel;

    private void OnEnable()
    {
        CharacterSpawn.onChangedCharacter += UpdateLevelText;
        CharacterLevel.onExpChanged += UpdateLevelText;
        
        UpdateLevelText();
    }

    private void OnDisable()
    {
        CharacterSpawn.onChangedCharacter -= UpdateLevelText;
        CharacterLevel.onExpChanged -= UpdateLevelText;
    }

    private void SetProgressFill ()
    {
        _cubeExp.fillAmount = Mathf.InverseLerp(0f, _character[SelectionCharacter].EnoughtExp, _character[SelectionCharacter].CurrentExp);
    }

    private void UpdateLevelText()
    {
        _textCubeLevel.SetText(_character[SelectionCharacter].CurrentLevel.ToString());
        _textCubeExp.SetText($"{_character[SelectionCharacter].CurrentExp}/{_character[SelectionCharacter].EnoughtExp}");

        SetProgressFill();
    }
}
