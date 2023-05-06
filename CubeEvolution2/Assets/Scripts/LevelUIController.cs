using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUIController : MonoBehaviour
{
    [SerializeField] private Image CubeExp;
    [SerializeField] private TextMeshProUGUI TextCubeExp;
    [SerializeField] private TextMeshProUGUI TextCubeLevel;
    [SerializeField] private DataCUBE DataEnemy;

    private float progressValue;

    void Update()
    {
        SetProgressFill();
    }

    private void SetProgressFill ()
    {
        progressValue = Mathf.InverseLerp(0f, DataEnemy.enoughtExp, DataEnemy.currentExp);
        CubeExp.fillAmount = progressValue;
        
        TextUpdateLevelCube();
    }

    private void TextUpdateLevelCube()
    {
        TextCubeLevel.SetText(DataEnemy.currentLevel.ToString());
        TextCubeExp.SetText(DataEnemy.currentExp + "/" + DataEnemy.enoughtExp);
    }
}
