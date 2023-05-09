using UnityEngine;

[CreateAssetMenu(fileName = "character", menuName = "Character")]
public class Character : ScriptableObject
{
    [SerializeField] private GameObject characterModel;
    public GameObject Model { get => characterModel; }

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    public string Name { get => _name; }
    public string Description { get => _description; }

    [SerializeField] private int unlockLevel;
    [SerializeField] private int unlockPrice;
    public int UnlockLevel { get => unlockLevel; }
    public int UnlockPrice { get => unlockPrice; }

    public int currentLevel;
    public int currentExp;

    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    public float Health { get => _health; }
    public float Damage { get => _damage; }
    public float Speed { get => _speed; }

}
