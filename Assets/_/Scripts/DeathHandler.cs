﻿using UnityEngine;

[RequireComponent(typeof(Health))]
public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _objectToDestroy;
    private readonly float _minHealth = 0f;
    
    private void Awake()
    {
        _health = GetComponent<Health>();
    }
    
    private void OnEnable()
    {
        _health.ChangedValue += Die;
    }
    
    private void OnDisable()
    {
        _health.ChangedValue -= Die;
    }
    
    private void Die()
    {
        if(_health.CurrentValue > _minHealth)
            return;
        
        Destroy(_objectToDestroy);
    }
}
