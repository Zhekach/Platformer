using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthKitCollector : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out HealthKit healthKit) == false)
            return;

        _health.Heal(healthKit.HealAmount);
        Destroy(healthKit.gameObject);
    }
}