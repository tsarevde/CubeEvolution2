using UnityEngine;

[CreateAssetMenu(fileName = "character", menuName = "Character")]
public class Character : ScriptableObject
{
    [Header("Character Model")]
    [SerializeField] private GameObject _characterModel;
    public GameObject Model { get => _characterModel; }

    [Header("Character Information")]
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    public string Name { get => _name; }
    public string Description { get => _description; }

    [Header("Character Requirement")]
    [SerializeField] private int _unlockLevel;
    [SerializeField] private int _unlockPrice;
    public int UnlockLevel { get => _unlockLevel; }
    public int UnlockPrice { get => _unlockPrice; }

    [Header("Character Stats")]
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    public float Health { get => _health; }
    public float Damage { get => _damage; }
    public float Speed { get => _speed; }

    [Header("Character Levels")]
    [SerializeField] private int _currentLevel = 1;
    [SerializeField] private int _maxLevel = 10;
    [SerializeField] private int _currentExp = 0;
    [SerializeField] private int _enoughtExp = 5;
    public int CurrentLevel { get => _currentLevel; }
    public int MaxLevel { get => _maxLevel; }
    public int CurrentExp { get => _currentExp; }
    public int EnoughtExp { get => _enoughtExp; }
}
