using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skill : CharacterSelection
{
    [Header("Main")]
    public TextMeshProUGUI _statusText;
    public Image _backgroundImage;
    private enum typeStatus
    {
        Active = 0,
        Complite = 1,
        Close = 2,
    }
    [SerializeField] private typeStatus selectStatus;
    [SerializeField] private Sprite _spriteActive;
    [SerializeField] private Sprite _spriteComplite;
    [SerializeField] private Sprite _spriteClose;

    [Header("Bonus (%)")]
    public TextMeshProUGUI _bonusText;
    public Image _bonusImage;
    private enum typeBonus
    {
        Health = 0,
        Damage = 1,
        Speed = 2,
    }
    [SerializeField] private typeBonus selectBonus;
    [SerializeField] private float _bonusEmount;
    [SerializeField] private Sprite _spriteHealth;
    [SerializeField] private Sprite _spriteDamage;
    [SerializeField] private Sprite _spriteSpeed;

    [Header("Price (%)")]
    public TextMeshProUGUI _priceText;
    public Image _currencyImage;
    public GameObject _buttonBuy;
    [SerializeField] private Sprite _spriteMoney;
    [SerializeField] private Sprite _spriteDonate;
    [SerializeField] private Sprite _spriteBuyEnable;
    [SerializeField] private Sprite _spriteBuyDisable;

    [Header("Data")]
    [SerializeField] private int _id;
    [SerializeField] private int _levelRequirement;
    [SerializeField] private float _price;
    [SerializeField] private bool _isDonate;
    [SerializeField] private bool _isComplite = false;

    [SerializeField] private float _bonusAmountAll;
    [SerializeField] private int _priceAll;

    private void OnEnable()
    {
        if (_character[SelectionCharacter].CurrentLevel < _levelRequirement && !_isComplite) selectStatus = typeStatus.Close;
        if (_character[SelectionCharacter].CurrentLevel >= _levelRequirement && !_isComplite) selectStatus = typeStatus.Active;

        if (SkillList.SkillsList[SelectionCharacter].SkillsComplite.Count != 0)
        {
            foreach (var i in SkillList.SkillsList[SelectionCharacter].SkillsComplite)
            {
                if (i == _id) selectStatus = typeStatus.Complite;
            }
        }

        SetPrice();
        SetBonus();
        SetStatus();
    }

    private void SetStatus(typeStatus type)
    {
        selectStatus = type;
        SetStatus();
    }

    //Цена
    private void SetPrice()
    {
        _priceAll = (int)(_price * _character[SelectionCharacter].UnlockPrice);
        _priceText.text = _priceAll.ToString();

        if (_isDonate) _currencyImage.sprite = _spriteDonate;
        else _currencyImage.sprite = _spriteMoney;
    }

    //Куплено, Доступно, Закрыто
    private void SetStatus()
    {
        switch(selectStatus)
        {
            case typeStatus.Active:
            {
                _backgroundImage.sprite = _spriteActive;
                _buttonBuy.SetActive(true);

                if (CheckMoney())
                {
                    _statusText.text = "UPGRADE NOW";
                    _buttonBuy.GetComponent<Button>().enabled = true;
                    _buttonBuy.GetComponent<Image>().sprite = _spriteBuyEnable;
                }
                else
                {
                    _statusText.text = "NOT ENOUGH MONEY";
                    _buttonBuy.GetComponent<Button>().enabled = false;
                    _buttonBuy.GetComponent<Image>().sprite = _spriteBuyDisable;
                }

                break;
            }
            case typeStatus.Complite:
            {
                _backgroundImage.sprite = _spriteComplite;
                _statusText.text = "COMPLITE";
                _buttonBuy.SetActive(false);
                break;
            }
            case typeStatus.Close:
            {
                _backgroundImage.sprite = _spriteClose;
                _statusText.text = $"YOU NEED LEVEL {_levelRequirement}";
                _buttonBuy.SetActive(false);
                break;
            }
        }
    }

    //Бонус за улучшение
    private void SetBonus()
    {
        switch(selectBonus)
        {
            case typeBonus.Health:
            {
                _bonusAmountAll = (int)(_bonusEmount / 100 * (_character[SelectionCharacter].HealthMax - _character[SelectionCharacter].StartHealth));
                _bonusImage.sprite = _spriteHealth;
                break;
            }
            case typeBonus.Damage:
            {
                _bonusAmountAll = (int)(_bonusEmount / 100 * (_character[SelectionCharacter].DamageMax - _character[SelectionCharacter].StartDamage));
                _bonusImage.sprite = _spriteDamage;
                break;
            }
            case typeBonus.Speed:
            {
                _bonusAmountAll = _bonusEmount / 100 * (_character[SelectionCharacter].SpeedMax - _character[SelectionCharacter].StartSpeed);
                _bonusImage.sprite = _spriteSpeed;
                break;
            }
        }

        _bonusText.text = $"+ {_bonusAmountAll}";
    }

    //Купить улучшение
    public void BuyUpgrade()
    {
        if (!CheckMoney()) return;

        if (_isDonate) UserData.TakeDonate(_priceAll);
        else UserData.TakeMoney(_priceAll);

        _isComplite = true;
        SkillList.SkillsList[SelectionCharacter].SkillsComplite.Add(_id);
        SetStatus(typeStatus.Complite);

        switch(selectBonus)
        {
            case typeBonus.Health:
            {
                _character[SelectionCharacter].Health += (int)_bonusAmountAll;
                break;
            }
            case typeBonus.Damage:
            {
                _character[SelectionCharacter].Damage += (int)_bonusAmountAll;
                break;
            }
            case typeBonus.Speed:
            {
                _character[SelectionCharacter].Speed += _bonusAmountAll;
                break;
            }
        }
    }

    //Проверка баланса
    private bool CheckMoney()
    {
        if (_isDonate) 
        {
            if (UserData.donate >= _priceAll) return true;
        }
        else
        {
            if (UserData.money >= _priceAll) return true;
        }    

        return false;
    }
    
}
