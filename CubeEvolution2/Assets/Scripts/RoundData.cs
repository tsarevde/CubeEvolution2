using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class RoundData : CharacterSelection
{
    public static Action<int> onGetPriorityFood;
    public static Action<int> onFoodAmount;
    public static Action onFoodTake;

    public int CreatureAmount {get; private set;} = 1;
    private static int _priorityFood;
    public int FoodAmount {get; private set;} = 0;
    public int KillsAmount = 0;
    [SerializeField] private RoundEnd _roundEnd;

    public void Start()
    {
        KillsAmount = 0;
        _priorityFood = Random.Range(1, 6);
        onGetPriorityFood?.Invoke(_priorityFood);

        CreatureHandler.onKilled += CreatureKilled;
    }

    private void OnDisable()
    {
        CreatureHandler.onKilled -= CreatureKilled;
    }

    public void TakeFood(int foodID)
    {
        if (foodID == _priorityFood)
        {
            FoodAmount++;
            onFoodAmount?.Invoke(FoodAmount);
            onFoodTake?.Invoke();
        }

        if (FoodAmount >= 5)
        {
            _roundEnd.WinRound();
        }
    }

    private void CreatureKilled()
    {
        KillsAmount++;
    }
}
