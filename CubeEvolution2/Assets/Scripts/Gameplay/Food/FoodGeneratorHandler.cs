using UnityEngine;
using System.Collections;

public class FoodGeneratorHandler : FoodGeneratorList
{
    [SerializeField] public int FoodGeneratorNumber = 0;
    [SerializeField] private int currentAmountFood = 0;
    [SerializeField] private int maxAmountFood = 5;

    private void Start()
    {
        RoundStarter.onRoundStart += StartSpawner;
    }

    private void OnDisable()
    {
        RoundStarter.onRoundStart -= StartSpawner;
    }

    private void StartSpawner()
    {
         StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            SpawnFood();
            yield return new WaitForSeconds(_foodGenerator[FoodGeneratorNumber].SpawnTime);
        }
    }

    private void SpawnFood()
    {
        if (currentAmountFood < maxAmountFood)
        {
            GameObject food = Instantiate(_foodGenerator[FoodGeneratorNumber].Food.FoodModel, transform.position + new Vector3(0, 0.375f, 0), transform.rotation);
            food.GetComponent<FoodHandler>().FoodGenerator = this;
            currentAmountFood++;
        }
    }

    public void FoodDestroy()
    {
        currentAmountFood--;
    }
}
