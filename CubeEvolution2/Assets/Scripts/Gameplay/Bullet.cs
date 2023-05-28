using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 _bulletDistance;
    [SerializeField] private float _range = 1.5f;

    public float Speed = 8f;
    public float Distance = 10f;

    public CreatureHandler CreatureSender;
    public int Damage;

    public static Action<int> onDamage;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * Speed;
        _bulletDistance = transform.position + transform.forward * Distance;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _bulletDistance) <= _range)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            other.gameObject.GetComponent<Wall>().Touch();
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag == "Creature")
        {
            if (!CreatureSender) onDamage?.Invoke(Damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
