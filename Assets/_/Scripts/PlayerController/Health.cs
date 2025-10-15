using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 10f;
    [SerializeField] private float _currentValue;
    
    public event Action OnHealthChanged;

    public float MaxValue => _maxValue;
    public float CurrentValue => _currentValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentException("Урон не может быть отрицательным");
        
        _currentValue = Mathf.Clamp(_currentValue - damage, 0, _maxValue);
        
        OnHealthChanged?.Invoke();
    }
    
    public void Heal(float heal)
    {
        _currentValue = Mathf.Clamp(_currentValue + heal, 0, _maxValue);
        
        OnHealthChanged?.Invoke();
    }
}