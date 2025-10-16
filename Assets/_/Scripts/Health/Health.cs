using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max = 100f;
    [SerializeField] private float _current;

    public event Action HealthChanged;
    
    public float Max => _max;
    public float Current => _current;

    private void Awake()
    {
        _current = _max;
    }

    public void TakeDamage(float damage)
    {
        _current = Mathf.Clamp(_current - damage, 0, _max);

        HealthChanged?.Invoke();
    }
    
    public void Heal(float heal)
    {
        _current = Mathf.Clamp(_current + heal, 0, _max);
        
        HealthChanged?.Invoke();
    }
}