using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacterStatistics : CharacterSelection
{
    [SerializeField] private List<TextMeshProUGUI> _textStatistics;

    private void Start()
    {
        CharacterSpawn.onChangedCharacter += SetData;
        SetData();
    }

    private void OnDisable()
    {
        CharacterSpawn.onChangedCharacter -= SetData;
    }


    public void SetData()
    {
        _textStatistics[0].SetText(_character[SelectionCharacter].StatisticsPlayed.ToString());
        _textStatistics[1].SetText(_character[SelectionCharacter].StatisticsVictories.ToString());
        _textStatistics[2].SetText(_character[SelectionCharacter].StatisticsLosses.ToString());
        _textStatistics[3].SetText(_character[SelectionCharacter].StatisticsKilled.ToString());
        _textStatistics[4].SetText(_character[SelectionCharacter].StatisticsDeaths.ToString());
        _textStatistics[5].SetText(_character[SelectionCharacter].StatisticsMaxKilled.ToString());
        _textStatistics[6].SetText(_character[SelectionCharacter].StatisticsBonuses.ToString());
        _textStatistics[7].SetText(_character[SelectionCharacter].StatisticsDamage.ToString());
        _textStatistics[8].SetText(_character[SelectionCharacter].StatisticsRegeneration.ToString());
        _textStatistics[9].SetText(_character[SelectionCharacter].StatisticsEaten.ToString());
    }
}
