using UnityEngine;
using System;

public class FoodHandler : MonoBehaviour
{
    //public static Action onFoodEaten;
    public FoodGeneratorHandler FoodGenerator;

    private void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(UnityEngine.Random.Range(-3f,3f), 3, UnityEngine.Random.Range(-3f,3f)), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Creature")
        {
            //onFoodEaten?.Invoke();
            if (FoodGenerator) FoodGenerator.FoodDestroy();
            Destroy(gameObject);
        }
    }
}
