public class CharacterSaveStats : CharacterSelection
{
    private void OnEnable()
    {
        RoundEnd.onVictory += StatisticsVictories;
        RoundEnd.onLoss += StatisticsLosses;
        RoundData.onFoodTake += StatisticsEaten;
        Bullet.onDamage += StatisticsDamage;
        CreatureHandler.onKilled += StatisticsKilled;
        CharacterHealth.onHealing += StatisticsRegeneration;
    }

    private void OnDisable()
    {
        RoundEnd.onVictory -= StatisticsVictories;
        RoundEnd.onLoss -= StatisticsLosses;
        RoundData.onFoodTake -= StatisticsEaten;
        Bullet.onDamage -= StatisticsDamage;
        CreatureHandler.onKilled -= StatisticsKilled;
        CharacterHealth.onHealing -= StatisticsRegeneration;
    }

    private void StatisticsPlayed() //
    { _character[SelectionCharacter].StatisticsPlayed++; }

    private void StatisticsVictories() //
    { _character[SelectionCharacter].StatisticsVictories++; StatisticsPlayed(); }

    private void StatisticsLosses() // 
    { _character[SelectionCharacter].StatisticsLosses++; StatisticsPlayed(); StatisticsDeaths(); }

    private void StatisticsKilled() //
    { _character[SelectionCharacter].StatisticsKilled++; }

    private void StatisticsDeaths() //
    { _character[SelectionCharacter].StatisticsDeaths++; }

    private void StatisticsMaxKilled(int value)
    { _character[SelectionCharacter].StatisticsMaxKilled = value; }

    private void StatisticsBonuses()
    { _character[SelectionCharacter].StatisticsBonuses++; }

    private void StatisticsDamage(int value) //
    { _character[SelectionCharacter].StatisticsDamage += value; }

    private void StatisticsRegeneration(int value) //
    { _character[SelectionCharacter].StatisticsRegeneration += value; }

    private void StatisticsEaten() //
    { _character[SelectionCharacter].StatisticsEaten++; }
}
