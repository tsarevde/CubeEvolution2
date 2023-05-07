using UnityEngine;

public abstract class Creature
{
    public float Health { get; protected set; }
    public float Damage { get; protected set; }
    public float Speed { get; protected set; }

    public void AddHealth(float addValue)
    {
        Health += addValue;
        Debug.Log($"GiveHealth: {addValue}");
    }

    public void SetHealth(float setValue)
    {
        Health = setValue;
        Debug.Log($"SetHealth {setValue}");
    }
}
