using System;
using UnityEngine;

public class RoundStarter : MonoBehaviour
{
    public bool isStartRound = false;
    public static Action onRoundStart;

    public void StartRound()
    {
        onRoundStart?.Invoke();
    }
}
