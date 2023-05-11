using UnityEngine;

public abstract class FoodGeneratorList : MonoBehaviour
{
    public FoodGenerator[] _foodGenerator {get; private set;}

    public void Awake()
    {
        _foodGenerator = Resources.LoadAll<FoodGenerator>("FoodGenerator");
    }
}
