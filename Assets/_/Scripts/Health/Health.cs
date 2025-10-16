using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100f;
    [SerializeField] private float _currentValue;

    public event Action ChangedValue;
    
    public float MaxValue => _maxValue;
    public float CurrentValue => _currentValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        _currentValue = Mathf.Clamp(_currentValue - damage, 0, _maxValue);

        ChangedValue?.Invoke();
    }
    
    public void Heal(float heal)
    {
        _currentValue = Mathf.Clamp(_currentValue + heal, 0, _maxValue);
        
        ChangedValue?.Invoke();
    }
}