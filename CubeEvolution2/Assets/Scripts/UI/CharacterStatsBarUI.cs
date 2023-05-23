using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsBarUI : CharacterSelection
{
    // Отображение прогресс бара статистик(здоровье, урон, скорость) персонажа в UI
    [SerializeField] private Image[] _statsMax;
    [SerializeField] private Image[] _currentStats;

    [Header("Max Upgrade Stats")]
    [SerializeField] private int _maxUpgradeHealth = 2000;
    [SerializeField] private int _maxUpgradeDamage = 500;
    [SerializeField] private int _maxUpgradeSpeed = 10;

    private void OnEnable()
    {
        CharacterSpawn.onChangedCharacter += SetProgressFill;
        SetProgressFill();
    }

    private void OnDisable()
    {
        CharacterSpawn.onChangedCharacter -= SetProgressFill;
    }

    private void SetProgressFill()
    {
        _currentStats[0].fillAmount = Mathf.InverseLerp(0f, _maxUpgradeHealth, _character[SelectionCharacter].Health);
        _statsMax[0].fillAmount = Mathf.InverseLerp(0f, _maxUpgradeHealth, _character[SelectionCharacter].HealthMax);
        
        _currentStats[1].fillAmount = Mathf.InverseLerp(0f, _maxUpgradeDamage, _character[SelectionCharacter].Damage);
        _statsMax[1].fillAmount = Mathf.InverseLerp(0f, _maxUpgradeDamage, _character[SelectionCharacter].DamageMax);

        _currentStats[2].fillAmount = Mathf.InverseLerp(0f, _maxUpgradeSpeed, _character[SelectionCharacter].Speed);
        _statsMax[2].fillAmount = Mathf.InverseLerp(0f, _maxUpgradeSpeed, _character[SelectionCharacter].SpeedMax);
    }
}
