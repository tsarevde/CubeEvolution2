using UnityEngine;

public class FoodGeneratorCreator : FoodGeneratorList
{   
    [SerializeField] private MapCreator _mapCreator;
    [SerializeField] private int index = 0;
    [SerializeField] private int generatorAmount;
    [SerializeField] private int[] lastCoordinates;

    void Start()
    {
        generatorAmount = _foodGenerator.Length;
        lastCoordinates = new int [generatorAmount];

        CreateGenerator();
    }

    private void CreateGenerator()
    {
        while (index != generatorAmount)
        {
            GetRandomNumber();
        }
    }

    private void GetRandomNumber()
    {
        int randomPosition = Random.Range(0, _mapCreator._mapCoordinates.Length-1);
        UniqueCheck(randomPosition);
    }

    private void UniqueCheck(int randomPosition)
    {
        for (int i = 0; i < lastCoordinates.Length - 1; i++)
        {
            if (lastCoordinates[i] == randomPosition)
            {
                GetRandomNumber();
                return;
            }
        }

        lastCoordinates[index] = randomPosition;
        SpawnObject(randomPosition);
    }

    private void SpawnObject(int randomPosition)
    {
        GameObject generator = Instantiate(_foodGenerator[index].FoodGeneratorModel, _mapCreator._mapCoordinates[randomPosition] + new Vector3(0, -0.5f, 0), transform.rotation, this.transform);
        generator.GetComponent<FoodGeneratorHandler>().FoodGeneratorNumber = index;

        index++;
    }
}
