using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 10f;

    private float _currentHealth;
    
    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void GetDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);

        if (_currentHealth == 0)
            Destroy(gameObject);
    }
}