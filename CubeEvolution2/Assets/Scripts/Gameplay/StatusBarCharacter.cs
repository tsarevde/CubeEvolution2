using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusBarCharacter : CharacterHolder
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
        _currentHealth = _character[CharacterSelection.SelectionCharacter].Health;
        _currentReloading = _character[CharacterSelection.SelectionCharacter].Reloading;
        
        SetProgressFill();
    }

    private void SetProgressFill()
    {
        _healthBar.fillAmount = Mathf.InverseLerp(0f, _character[CharacterSelection.SelectionCharacter].Health, _currentHealth);
        _reloadingBar.fillAmount = Mathf.InverseLerp(0f, _character[CharacterSelection.SelectionCharacter].Reloading, _currentReloading);

        _healthText.SetText(_currentHealth.ToString());
    }
}

