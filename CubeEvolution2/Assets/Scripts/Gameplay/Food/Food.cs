using UnityEngine;

[CreateAssetMenu(fileName = "food", menuName = "Food")]
public class Food : ScriptableObject
{
    [Header("Food Model")]
    [SerializeField] private GameObject _foodModel;
    public GameObject FoodModel { get => _foodModel; }

    [Header("Food Stats")]
    [SerializeField] private float _foodPoint;
    public float FoodPoint { get => _foodPoint; }
}
