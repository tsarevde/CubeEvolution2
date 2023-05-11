using UnityEngine;
using TMPro;
using System.Collections;


[RequireComponent(typeof(TextMeshProUGUI))]
public class RoundTimer : MonoBehaviour
{
    [SerializeField] private int second = 0;
    [SerializeField] private int minutes = 0;
    [SerializeField] private TextMeshProUGUI textTimer;

    void Start()
    {
        ResetTimer();
        StartCoroutine(Timer());
    }

    private void ResetTimer()
    {
        second = 0;
        minutes = 0;
    }

    IEnumerator Timer()
    {
        while (true)
        {
            if (second == 59)
            {
                minutes++;
                second = 0;
            }

            second++;
            
            if (second < 10)
                textTimer.SetText($"{minutes}:0{second}");
            else
                textTimer.SetText($"{minutes}:{second}");

            yield return new WaitForSeconds(1f);
        }
    }
}
