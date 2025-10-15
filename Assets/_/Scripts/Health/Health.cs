using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 10f;
    [SerializeField] private float _currentValue;

    public event Action OnHealthChanged;
    
    public float MaxHealth => _maxHealth;
    public float CurrentValue => _currentValue;

    private void Awake()
    {
        _currentValue = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentValue = Mathf.Clamp(_currentValue - damage, 0, _maxHealth);

        OnHealthChanged?.Invoke();
    }
    
    public void Heal(float heal)
    {
        _currentValue = Mathf.Clamp(_currentValue + heal, 0, _maxHealth);
        
        OnHealthChanged?.Invoke();
    }
}