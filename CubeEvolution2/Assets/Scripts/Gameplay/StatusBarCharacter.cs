using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusBarCharacter : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _reloadingBar;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _currentReloading;

    public RoundData data;

    public void SetPosition(Vector3 characterPosition)
    {
        transform.position = characterPosition;
    }

    private void Start()
    {
        CharacterAttack.onReloadingAmmo += ReloadingBar;
        
        _currentHealth = data._character[CharacterSelection.SelectionCharacter].Health;
        
        UpdateHealthBar();
        ReloadingBar(data._character[CharacterSelection.SelectionCharacter].Reloading);
    }

    private void OnDisable()
    {
       CharacterAttack.onReloadingAmmo -= ReloadingBar;
    }

    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = Mathf.InverseLerp(0f, data._character[CharacterSelection.SelectionCharacter].Health, _currentHealth);

        _healthText.SetText(_currentHealth.ToString());
    }

    private void ReloadingBar(float currentTime)
    {
        _reloadingBar.fillAmount = Mathf.InverseLerp(0f, data._character[CharacterSelection.SelectionCharacter].Reloading, currentTime);
    }
}

