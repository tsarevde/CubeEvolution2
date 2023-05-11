using UnityEngine;

[CreateAssetMenu(fileName = "creature", menuName = "Creature")]
public class Creature : ScriptableObject
{
    [Header("Creature Model")]
    [SerializeField] private GameObject _characterModel;
    public GameObject Model { get => _characterModel; }


    [Header("Creature Information")]
    [SerializeField] private string _name;

    [Header("Creature Stats")]
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _healthMax;
    [SerializeField] private float _damageMax;
    [SerializeField] private float _speedMax;
    public float Health { get => _health; set => _health = value;}
    public float Damage { get => _damage; set => _damage = value;}
    public float Speed { get => _speed; set => _speed = value;}
    public float HealthMax { get => _healthMax; }
    public float DamageMax { get => _damageMax; }
    public float SpeedMax { get => _speedMax; }
}
