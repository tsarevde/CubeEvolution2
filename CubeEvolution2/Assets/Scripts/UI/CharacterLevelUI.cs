using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterLevelUI : CharacterList
{
    [SerializeField] private Image CubeExp;
    [SerializeField] private TextMeshProUGUI TextCubeExp;
    [SerializeField] private TextMeshProUGUI TextCubeLevel;

    private float progressValue;

    private void Start()
    {
        CharacterSelection.onChangedCharacter += UpdateLevelText;
        UpdateLevelText();
    }

    private void OnDisable()
    {
        CharacterSelection.onChangedCharacter -= UpdateLevelText;
    }

    private void SetProgressFill (int selectedIndex)
    {
        progressValue = Mathf.InverseLerp(0f, _character[selectedIndex].EnoughtExp, _character[selectedIndex].CurrentExp);
        CubeExp.fillAmount = progressValue;
    }

    private void UpdateLevelText()
    {
        int selectedIndex = CharacterSelection.SelectionCharacter;

        TextCubeLevel.SetText(_character[selectedIndex].CurrentLevel.ToString());
        TextCubeExp.SetText($"{_character[selectedIndex].CurrentExp}/{_character[selectedIndex].EnoughtExp}");

        SetProgressFill(selectedIndex);
    }
}
