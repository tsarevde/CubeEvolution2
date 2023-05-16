using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusBarCharacter : CharacterSelection
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _reloadingBar;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _currentReloading;
    
    [SerializeField] private Image _foodTexture;
    [SerializeField] private TextMeshProUGUI _foodAmount;
    [SerializeField] private Color _foodColor;

    public void SetPosition(Vector3 characterPosition)
    {
        transform.position = characterPosition;
    }

    private void Start()
    {
        CharacterAttack.onReloadingAmmo += ReloadingBar;
        RoundData.onGetPriorityFood += SetFoodColor;
        RoundData.onFoodTake += FoodInfoUpdate;
        
        _currentHealth = _character[CharacterSelection.SelectionCharacter].Health;
        
        UpdateHealthBar();
        ReloadingBar(_character[CharacterSelection.SelectionCharacter].Reloading);
    }

    private void OnDisable()
    {
        CharacterAttack.onReloadingAmmo -= ReloadingBar;
        RoundData.onFoodTake -=FoodInfoUpdate;
        RoundData.onGetPriorityFood -= SetFoodColor;
    }

    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = Mathf.InverseLerp(0f, _character[CharacterSelection.SelectionCharacter].Health, _currentHealth);

        _healthText.SetText(_currentHealth.ToString());
    }

    private void ReloadingBar(float currentTime)
    {
        _reloadingBar.fillAmount = Mathf.InverseLerp(0f, _character[CharacterSelection.SelectionCharacter].Reloading, currentTime);
    }

    private void SetFoodColor(int number)
    {
        switch (number)
        {
            case 1:
            {
                _foodTexture.color = Color.white;
                break;
            }
            case 2:
            {
                _foodTexture.color = Color.green;
                break;
            }
            case 3:
            {
                _foodTexture.color = Color.blue;
                break;
            }
            case 4:
            {
                _foodTexture.color = Color.yellow;
                break;
            }
            case 5:
            {
                _foodTexture.color = Color.red;
                break;
            }
            case 6:
            {
                _foodTexture.color = Color.magenta;
                break;
            }
        }
    }

    private void FoodInfoUpdate(int foodAmount)
    {
        _foodAmount.SetText(foodAmount.ToString());
    }
}

