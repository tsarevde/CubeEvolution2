using UnityEngine;
using System;
using System.Collections;

public class CharacterAttack : CharacterSelection
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private GameObject _point;

    [SerializeField] private int _startDamage;
    [SerializeField] private int _currentDamage;

    [SerializeField] public GameObject ShootLine;
    private bool _isHaveAmmo = true;
    public static Action<float> onReloadingAmmo;

    private void Start()
    {
        _startDamage = _character[SelectionCharacter].Damage;
        _currentDamage = _startDamage;

        RoundData.onFoodTake += AddDamage;
    }

    private void OnDisable()
    {
        RoundData.onFoodTake -= AddDamage;
    }

    private void AddDamage()
    {
        _currentDamage += (int)(_startDamage * .1f);
    }

    public void SetAttackDirection(Vector3 direction)
    {
        Ray ray = new Ray(_shootPoint.transform.position + new Vector3(0, -.498f, 0), _shootPoint.transform.forward);

        RaycastHit _hit;
        if (Physics.Raycast(ray, out _hit, _character[SelectionCharacter].AttackDistance))
        {
            ShowLine(_hit.distance);
        }
        else
        {
            ShowLine(_character[SelectionCharacter].AttackDistance);
        }

    }

    private void ShowLine(float distance)
    {
            ShootLine.transform.localScale = new Vector3(1, distance, 1);
            ShootLine.transform.localPosition = new Vector3(0, -1.19f, distance/2);
    }

    public void RotateShootPoint(Vector3 rotateDirection) 
    {
        if (Vector3.Angle(_shootPoint.transform.forward, rotateDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(_shootPoint.transform.forward, rotateDirection, 5, 0);
            _shootPoint.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    public void Shoot()
    {
        if (_isHaveAmmo) StartCoroutine(SpawnBullet());
    }

    private IEnumerator SpawnBullet()
    {
        _isHaveAmmo = false;

        for (int i = 0; i < _character[SelectionCharacter].BulletAmount; i++)
        {
            GameObject bullet = Instantiate(_bullet, _point.transform.position, _point.transform.rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            
            bulletScript.Damage = _currentDamage;
            bulletScript.Speed = _character[SelectionCharacter].BulletSpeed;
            bulletScript.Distance = _character[SelectionCharacter].AttackDistance;

            yield return new WaitForSeconds(.2f);
        }

        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        float second = 0;

        while (second < _character[SelectionCharacter].Reloading)
        {
            onReloadingAmmo?.Invoke(second);

            second += .05f;
            yield return new WaitForSeconds(.05f);
        }

        _isHaveAmmo = true;
    }
}
