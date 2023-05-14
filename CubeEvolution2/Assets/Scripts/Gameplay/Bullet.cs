using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] private Vector3 _bulletDistance;
    [SerializeField] private float dist = 10;
    [SerializeField] private float range = 1.5f;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * _speed;
        _bulletDistance = transform.position + transform.forward * dist;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _bulletDistance) <= range)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Creature")
        {
            other.gameObject.GetComponent<Wall>().Touch();
            Destroy(gameObject);
        }
    }
}
