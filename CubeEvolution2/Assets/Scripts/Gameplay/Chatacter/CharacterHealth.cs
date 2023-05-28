using System.Collections;
using UnityEngine;
using System;

public class CharacterHealth : CharacterSelection
{
    public static Action<int> onHealing;
    public static Action<int> onChangeMaxHealth;
    public static Action<int> onTakeDamage;
    public static Action<int> onChangeHealth;

    [SerializeField] private int _startHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;

    [SerializeField] private int _noFightTime;
    [SerializeField] private int _noFightTimeSecond {get;} = 5;
    [SerializeField] private bool _inFight = false;

    [SerializeField] private RoundEnd _roundEnd;

    private void Start()
    {
        RoundData.onFoodTake += AddMaxHealth;

        _startHealth = _character[SelectionCharacter].Health;
        _maxHealth = _startHealth;
        _currentHealth = _maxHealth;

        _noFightTime = _noFightTimeSecond;

        StartCoroutine(InDeathZone());
    }

    private void OnDisable()
    {
        RoundData.onFoodTake -= AddMaxHealth;
    }

    private void TakeDamage(CreatureHandler sender, int damageValue)
    {
        if (_currentHealth - damageValue <= 0) _roundEnd.LoseRound();
        else 
        {
            _inFight = true;

            _currentHealth -= damageValue;
            onTakeDamage?.Invoke(_currentHealth);

            StartCoroutine(InFightTimer());
        }
    }

    private void TakeDamage(int damageValue)
    {
        if (_currentHealth - damageValue <= 0) _roundEnd.LoseRound();
        else 
        {
            _inFight = true;
            
            _currentHealth -= damageValue;
            onTakeDamage?.Invoke(_currentHealth);

            StartCoroutine(InFightTimer());
        }
    }

    private void TakeHealth(int healthValue)
    {
        _currentHealth += healthValue;

        onHealing?.Invoke(healthValue);
        onChangeHealth?.Invoke(_currentHealth);
    }

    private void AddMaxHealth()
    {
        _maxHealth += (int)(_startHealth * .1f);
        onChangeMaxHealth?.Invoke(_maxHealth);
        StartCoroutine(Regeneration());
    }


    private IEnumerator Regeneration()
    {
        while (!_inFight && _currentHealth < _maxHealth)
        {
            int regenerationValue = (int)(_startHealth * .01f);

            if (_currentHealth + regenerationValue < _maxHealth)
                _currentHealth += regenerationValue;
            else _currentHealth = _maxHealth;

            onHealing?.Invoke(regenerationValue);
            onChangeHealth?.Invoke(_currentHealth);

            yield return new WaitForSeconds(.25f);
        }
    }

    private IEnumerator InFightTimer()
    {
        _noFightTime = _noFightTimeSecond;

        while (_noFightTime > 0)
        {
            _noFightTime--;
            yield return new WaitForSeconds(1f);
        }

        _inFight = false;
        StartCoroutine(Regeneration());
    }

    private IEnumerator InDeathZone()
    {
        while (true)
        {
            if (DeathZone.isOutsideCircleStatic(transform.position))
                TakeDamage((int)DeathZone.Damage);

            yield return new WaitForSeconds(1f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(other.gameObject.GetComponent<Bullet>().CreatureSender, other.gameObject.GetComponent<Bullet>().CreatureSender.Damage);
        }
    }
}
