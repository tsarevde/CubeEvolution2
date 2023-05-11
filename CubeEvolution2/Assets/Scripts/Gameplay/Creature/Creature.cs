using UnityEngine;

[CreateAssetMenu(fileName = "creature", menuName = "Creature")]
public class Creature : ScriptableObject
{
    [Header("Creature Model")]
    [SerializeField] private GameObject creatureModel;
    public GameObject Model { get => creatureModel; }


    [Header("Creature Information")]
    [SerializeField] private string _name;

    [Header("Creature Stats")]
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    public float Health { get => _health; set => _health = value;}
    public float Damage { get => _damage; set => _damage = value;}
    public float Speed { get => _speed; set => _speed = value;}

    [SerializeField] private float _eatPoint;
    public float EatPoint { get => _eatPoint; set => _eatPoint = value;}
}
