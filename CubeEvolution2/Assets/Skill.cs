using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skill : MonoBehaviour
{
    [Header("Main")]
    public TextMeshProUGUI _statusText;
    public Image _backgroundImage;

    [Header("Bonus")]
    public TextMeshProUGUI _bonusText;
    public Image _bonusImage;

    [Header("Price")]
    public TextMeshProUGUI _priceText;
    public Image _currencyImage;

    [Header("Data")]
    [SerializeField] private int _levelRequirement;
    [SerializeField] private int _price;
    [SerializeField] private bool _isDonate;
    [SerializeField] private int _addHealth;
    [SerializeField] private int _addDamage;
    [SerializeField] private int _addSpeed;
}
