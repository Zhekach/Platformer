using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class HealthKitCollector : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out HealthKit healthKit) == false)
            return;

        _playerHealth.Heal(healthKit.HealAmount);
        Destroy(healthKit.gameObject);
    }
}