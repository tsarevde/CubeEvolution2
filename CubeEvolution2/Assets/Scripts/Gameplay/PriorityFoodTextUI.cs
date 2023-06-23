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
                _PriorityFoodText.SetText("WHITE");
                break;
            }
            case 2:
            {
                _PriorityFoodText.SetText("GREEN");
                break;
            }
            case 3:
            {
                _PriorityFoodText.SetText("BLUE");
                break;
            }
            case 4:
            {
                _PriorityFoodText.SetText("YELLOW");
                break;
            }
            case 5:
            {
                _PriorityFoodText.SetText("RED");
                break;
            }
            case 6:
            {
                _PriorityFoodText.SetText("MAGENTA");
                break;
            }
        }
    }
}
