using System;
using UnityEngine;

public class RoundStarter : MonoBehaviour
{
    public static Action onRoundStart;

    public void StartRound()
    {
        onRoundStart?.Invoke();
    }
}
