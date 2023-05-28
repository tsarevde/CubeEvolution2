using System.Collections;
using System.Collections.Generic;

using System;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;
using Unity.MLAgents.Actuators;
using Random = UnityEngine.Random;

public class CreatureHandler : Agent
{
    public float score = 0 ;
    
    [SerializeField] private Transform _point;
    [SerializeField] private GameObject _bullet;
    
    private bool _isReaload = true;
    private int _reloadingTime = 0;
    
    private Vector3 _startPosition;
    private Rigidbody _rigidBody;

    public Action OnEnvironmentReset;
    public int Health = 250;
    public int Damage = 43;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _rotationSpeed = 3f;
    public static Action onKilled;

    public override void Initialize()
    {
        _startPosition = transform.position;
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!_isReaload)
        {
            _reloadingTime--;

            if (_reloadingTime <= 0)
                _isReaload = true;
        }
        
        AddReward(-1f/MaxStep);
        score -= 1f/MaxStep;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(_isReaload);
        sensor.AddObservation(transform.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (Mathf.RoundToInt(actions.ContinuousActions[0]) >= 1)
        {
            Shoot();
        }

        _rigidBody.velocity = new Vector3(actions.ContinuousActions[1] * _speed, 0f, actions.ContinuousActions[2] * _speed);
        transform.Rotate(Vector3.up, actions.ContinuousActions[3] * _rotationSpeed);
    }

    public override void OnEpisodeBegin()
    {
        OnEnvironmentReset?.Invoke();
        
        score = 0;
        Health = 250;
        Damage = 47;

        transform.position = _startPosition + new Vector3 (Random.Range(-20, 20), 0 , Random.Range(-20, 20));
        transform.rotation = new Quaternion(0, Random.Range(0, 360), 0, 0);
        _rigidBody.velocity = Vector3.zero;
        _isReaload = true;
    }

    private void Shoot()
    {
        if (!_isReaload)
            return;

        _isReaload = false;
        _reloadingTime = 5;

        AddReward(-0.25f);

        GameObject bullet = Instantiate(_bullet, _point.transform.position, _point.transform.rotation);
        bullet.GetComponent<Bullet>().CreatureSender = this;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            AddReward(-1f);
            score -= 1f;
            //EndEpisode();
            if (other.gameObject.GetComponent<Bullet>().CreatureSender) 
                TakeDamage(other.gameObject.GetComponent<Bullet>().CreatureSender, other.gameObject.GetComponent<Bullet>().Damage);
            else TakeDamage(other.gameObject.GetComponent<Bullet>().Damage);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            AddReward(-5.0f);
            score -= 5.0f;
            EndEpisode();
        }

        if (other.gameObject.CompareTag("Food"))
        {
            AddReward(+8.5f);
            score += 8.5f;
            Health = (int)(Health * 1.20f);
            Health = (int)(Damage * 1.20f);
            //EndEpisode();
        }
    }

    public void TakeDamage(CreatureHandler sender, int damage)
    {
        if (Health - damage <= 0)
        {
            sender.RegisterKill();
            EndEpisode();
        }

        else Health -= damage;
        sender.RegisterHit();
    }

    public void TakeDamage(int damage)
    {
        if (Health - damage <= 0)
        {
            onKilled?.Invoke();
            EndEpisode();
        }

        else Health -= damage;
    }

    public void RegisterKill()
    {
        AddReward(10.0f);
        score += 10f;
    }

    public void RegisterHit()
    {
        AddReward(1.5f);
        score += -1.5f;
    }
}
