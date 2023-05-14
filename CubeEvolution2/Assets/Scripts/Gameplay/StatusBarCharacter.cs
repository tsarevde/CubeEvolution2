using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StatusBarCharacter : CharacterList
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _reloadingBar;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _currentReloading;

    public void SetPosition(Vector3 characterPosition)
    {
        transform.position = characterPosition;
    }

    private void Start()
    {
        CharacterAttack.onReloadingAmmo += ReloadingBar;
        
        _currentHealth = _character[CharacterSelection.SelectionCharacter].Health;
        
        UpdateHealthBar();
        ReloadingBar(_character[CharacterSelection.SelectionCharacter].Reloading);
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
}

