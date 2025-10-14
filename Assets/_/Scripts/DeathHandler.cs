using UnityEngine;

[RequireComponent(typeof(Health))]
public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Health _health;
    private readonly float _minHealth = 0f;
    
    private void Awake()
    {
        _health = GetComponent<Health>();
    }
    
    private void OnEnable()
    {
        _health.OnHealthChanged += Die;
    }
    
    private void OnDisable()
    {
        _health.OnHealthChanged -= Die;
    }
    
    private void Die()
    {
        if(_health.CurrentValue > _minHealth)
            return;
        
        Destroy(gameObject);
    }
}
