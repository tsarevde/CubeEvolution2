using UnityEngine;
using System.Collections;

public class FoodHandler : MonoBehaviour
{
    public FoodGeneratorHandler FoodGenerator;
    public int ID;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(UnityEngine.Random.Range(-5f,5f), 4, UnityEngine.Random.Range(-5f,5f)), ForceMode.Impulse);
        StartCoroutine( Destroyed());
    }

    private void OnCollisionEnter(Collision other) 
    {
        if  (other.gameObject.tag == "Player" )
        {
            if (FoodGenerator) FoodGenerator.FoodDestroy();
            Destroy(gameObject);
            
            other.gameObject.GetComponent<RoundData>().TakeFood(ID);
        }
        else if ( other.gameObject.tag == "Creature" )
        {
            if (FoodGenerator) FoodGenerator.FoodDestroy();
            Destroy(gameObject);
        }
    }

    private IEnumerator Destroyed()
    {
        while (true)
        {
            yield return new WaitForSeconds(300f);
            Destroy(gameObject);
        }
    }
}
