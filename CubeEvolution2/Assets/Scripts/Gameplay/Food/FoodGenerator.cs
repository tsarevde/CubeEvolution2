using UnityEngine;

[CreateAssetMenu(fileName = "foodGenerator", menuName = "FoodGenerator")]
public class FoodGenerator : ScriptableObject
{
    [Header("Models")]
    [SerializeField] private GameObject _foodGeneratorModel;
    [SerializeField] private Food _food;
    public GameObject FoodGeneratorModel { get => _foodGeneratorModel; }
    public Food Food { get => _food; }

    [Header("FoodGenerator Stats")]
    [SerializeField] private float _spawnTime;
    public float SpawnTime { get => _spawnTime; }
}
