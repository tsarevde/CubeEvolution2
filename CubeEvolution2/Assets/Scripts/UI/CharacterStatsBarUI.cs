using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsBarUI : CharacterList
{
    // Отображение прогресс бара статистик(здоровье, урон, скорость) персонажа в UI
    [SerializeField] private Image[] _statsMax;
    [SerializeField] private Image[] _currentStats;
    private float progressValue;

    private void Start()
    {
        CharacterSelection.onChangedCharacter += SetProgressFill;
        SetProgressFill();
    }

    private void OnDisable()
    {
        CharacterSelection.onChangedCharacter -= SetProgressFill;
    }

    private void SetProgressFill()
    {
        int selectedIndex = CharacterSelection.SelectionCharacter;

        progressValue = Mathf.InverseLerp(0f, Character.StatsMax, _character[selectedIndex].Health);
        _currentStats[0].fillAmount = progressValue;
        progressValue = Mathf.InverseLerp(0f, Character.StatsMax, _character[selectedIndex].HealthMax);
        _statsMax[0].fillAmount = progressValue;
        
        progressValue = Mathf.InverseLerp(0f, Character.StatsMax, _character[selectedIndex].Damage);
        _currentStats[1].fillAmount = progressValue;
        progressValue = Mathf.InverseLerp(0f, Character.StatsMax, _character[selectedIndex].DamageMax);
        _statsMax[1].fillAmount = progressValue;

        progressValue = Mathf.InverseLerp(0f, Character.StatsMax, _character[selectedIndex].Speed);
        _currentStats[2].fillAmount = progressValue;
        progressValue = Mathf.InverseLerp(0f, Character.StatsMax, _character[selectedIndex].SpeedMax);
        _statsMax[2].fillAmount = progressValue;
    }
}
