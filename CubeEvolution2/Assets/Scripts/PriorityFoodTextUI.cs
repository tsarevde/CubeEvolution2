using UnityEngine;
using TMPro;

public class PriorityFoodTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _PriorityFoodText;
    private void Awake()
    {
        _PriorityFoodText = GetComponent<TextMeshProUGUI>();
        RoundData.onGetPriorityFood += SetTextPriorityFood;
    }

    private void OnDisable()
    {
        RoundData.onGetPriorityFood -= SetTextPriorityFood;
    }

    private void SetTextPriorityFood(int number)
    {
        switch (number)
        {
            case 1:
            {
                _PriorityFoodText.SetText("БЕЛЫЕ");
                break;
            }
            case 2:
            {
                _PriorityFoodText.SetText("ЗЕЛЕНЫЕ");
                break;
            }
            case 3:
            {
                _PriorityFoodText.SetText("СИНИЕ");
                break;
            }
            case 4:
            {
                _PriorityFoodText.SetText("ЖЕЛТЫЕ");
                break;
            }
            case 5:
            {
                _PriorityFoodText.SetText("КРАСНЫЕ");
                break;
            }
            case 6:
            {
                _PriorityFoodText.SetText("ФИОЛЕТОВЫЕ");
                break;
            }
        }
    }
}
