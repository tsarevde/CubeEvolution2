using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    public FoodGeneratorHandler FoodGenerator;
    public int ID;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(UnityEngine.Random.Range(-5f,5f), 4, UnityEngine.Random.Range(-5f,5f)), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            if (FoodGenerator) FoodGenerator.FoodDestroy();
            
            other.gameObject.GetComponent<RoundData>().TakeFood(ID);
            Destroy(gameObject);
        }
    }
}
