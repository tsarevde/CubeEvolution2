using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class RoundData : CharacterSelection
{
    public int CreatureAmount {get; private set;} = 1;
    public static Action<int> onGetPriorityFood;
    public static Action<int> onFoodTake;
    private static int _priorityFood;
    public int FoodAmount {get; private set;} = 0;

    public void Start()
    {
        _priorityFood = Random.Range(1, 6);
        onGetPriorityFood?.Invoke(_priorityFood);
    }

    public void TakeFood(int foodID)
    {
        if (foodID == _priorityFood)
        {
            FoodAmount++;
            onFoodTake?.Invoke(FoodAmount);
        }
    }
}
