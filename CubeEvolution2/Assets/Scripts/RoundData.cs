using System;

public class RoundData : CharacterSelection
{
    public static Action<int> onGetPriorityFood;
    public int PriorityFood = 0;

    private void Start()
    {
        GetPriorityFood();
    }

    private void GetPriorityFood()
    {
        PriorityFood = SetPriorityFood.GetPriorityFood();
        onGetPriorityFood?.Invoke(PriorityFood);
    }
}
