using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TMPro;

public class RoundEnd : MonoBehaviour
{
    public static Action onRoundEnd;

    [SerializeField] private Image _background;
    [SerializeField] private TextMeshProUGUI _statusText;
    [SerializeField] private TextMeshProUGUI _statusInfoText;
    [SerializeField] private TextMeshProUGUI _expText;
    [SerializeField] private TextMeshProUGUI _moneyText;

    [SerializeField] private GameObject _fadeIn;

    [SerializeField] private int _exp;
    [SerializeField] private int _money;

    public void FadeInActivate()
    {
        _fadeIn.gameObject.SetActive(true);
        _fadeIn.GetComponent<ScenesChanger>().SelectScreen(0);
    }

    public void WinRound()
    {
        gameObject.SetActive(true);

        _background.color = new Color32(74, 190, 255, 224);
        _statusText.SetText("YOU HAVE WON");
        _statusInfoText.SetText("FOR WINNING THE GAME");

        onRoundEnd?.Invoke();

        CheckTextStatus();
    }

    public void LoseRound()
    {
        gameObject.SetActive(true);
        
        _background.color = new Color32(255, 74, 74, 224);
        _statusText.SetText("YOU'VE LOST");
        _statusInfoText.SetText("FOR PARTICIPATING IN THE GAME");

        onRoundEnd?.Invoke();

        CheckTextStatus();
    }

    private void CheckTextStatus()
    {
        if (_exp == 0) _expText.gameObject.SetActive(false);
        if (_money == 0) _moneyText.gameObject.SetActive(false);
    }

    private void SetTextExp()
    {
        Debug.Log("SetTextExp");
        StartCoroutine(UpdaterTextBonus(_expText, _exp, "EXP"));
    }

    private void SetTextMoney()
    {
        Debug.Log("SetTextMoney");
        StartCoroutine(UpdaterTextBonus(_moneyText, _money, "$"));
    }

    IEnumerator UpdaterTextBonus(TextMeshProUGUI curentText, int needAmount, string currency)
    {
        int curretAmount = 0;
        int addAmount = needAmount / 20;

        while (needAmount > curretAmount)
        {
            curentText.SetText($"+{curretAmount} {currency}");

            curretAmount += addAmount;

            yield return new WaitForSeconds(.05f);
        }
    }
}
