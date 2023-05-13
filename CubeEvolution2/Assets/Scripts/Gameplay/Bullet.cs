using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    
    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * _speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Creature")
        {
            Destroy(gameObject);
        }
    }
}
