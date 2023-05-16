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
                _foodTexture.color = new Color32(72, 222, 54, 255);
                break;
            }
            case 3:
            {
                _foodTexture.color = new Color32(32, 206, 255, 255);
                break;
            }
            case 4:
            {
                _foodTexture.color = new Color32(255, 192, 23, 255);
                break;
            }
            case 5:
            {
                _foodTexture.color = new Color32(221, 50, 44, 255);
                break;
            }
            case 6:
            {
                _foodTexture.color = new Color32(225, 96, 248, 255);
                break;
            }
        }
    }

    private void FoodInfoUpdate(int foodAmount)
    {
        _foodAmount.SetText(foodAmount.ToString());
    }
}

