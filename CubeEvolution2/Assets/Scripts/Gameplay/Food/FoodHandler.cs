using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    //public static Action onFoodEaten;
    public FoodGeneratorHandler FoodGenerator;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(UnityEngine.Random.Range(-5f,5f), 4, UnityEngine.Random.Range(-5f,5f)), ForceMode.Impulse);
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
