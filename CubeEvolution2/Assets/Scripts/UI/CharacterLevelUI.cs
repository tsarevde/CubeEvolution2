using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterLevelUI : CharacterLevel
{
    // Отображение уровня игрока в UI
    [SerializeField] private Image CubeExp;
    [SerializeField] private TextMeshProUGUI TextCubeExp;
    [SerializeField] private TextMeshProUGUI TextCubeLevel;

    private void Start()
    {
        CharacterSpawn.onChangedCharacter += UpdateLevelText;
        onExpChanged += UpdateLevelText;
        UpdateLevelText();
    }

    private void OnDisable()
    {
        CharacterSpawn.onChangedCharacter -= UpdateLevelText;
        onExpChanged -= UpdateLevelText;
    }

    private void SetProgressFill ()
    {
        CubeExp.fillAmount = Mathf.InverseLerp(0f, _character[SelectionCharacter].EnoughtExp, _character[SelectionCharacter].CurrentExp);
    }

    private void UpdateLevelText()
    {

        TextCubeLevel.SetText(_character[SelectionCharacter].CurrentLevel.ToString());
        TextCubeExp.SetText($"{_character[SelectionCharacter].CurrentExp}/{_character[SelectionCharacter].EnoughtExp}");

        SetProgressFill();
    }
}
