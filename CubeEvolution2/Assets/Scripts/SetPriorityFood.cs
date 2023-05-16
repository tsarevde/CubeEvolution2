using Random = UnityEngine.Random;

public static class SetPriorityFood
{
    public static int GetPriorityFood()
    {
        return Random.Range(1, 6);
    }
}
