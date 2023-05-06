using UnityEngine;

public class DataCUBE : MonoBehaviour
{
    public int currentLevel {get; private set;}
    public int maxLevel {get; private set;}
    public int currentExp;
    public int enoughtExp {get; private set;}

    private void Start() 
    {
        currentLevel = 1;
        maxLevel = 10;
        currentExp = 0;
        enoughtExp = 5;
    }

    public void ExpGive(int value)
    {
        if (value > 0)
            currentExp += value;

        if (currentExp >= enoughtExp)
            LevelUP();
    }

    private void LevelUP()
    {
        currentExp -= enoughtExp;
        currentLevel += 1;
        enoughtExp = Mathf.CeilToInt(enoughtExp*1.15f);
    }
}
