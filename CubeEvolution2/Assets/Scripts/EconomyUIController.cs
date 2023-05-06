using UnityEngine;
using TMPro;

public class EconomyUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextMoney;
    [SerializeField] private TextMeshProUGUI TextDonate;

    void Start()
    {
        TextUpdateMoney();
        TextUpdateDonate();
    }

    public void TextUpdateMoney()
    {
        TextMoney.SetText(UserData.money.ToString());
    }
    public void TextUpdateDonate()
    {
        TextDonate.SetText(UserData.donate.ToString());
    }
}
