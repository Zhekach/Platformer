using UnityEngine;

public abstract class HealthIndicator : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected virtual void Start()
    {
        UpdateInfo();
    }

    protected void OnEnable()
    {
        Health.HealthChanged += UpdateInfo;
    }
    
    protected void OnDisable()
    {
        Health.HealthChanged -= UpdateInfo;
    }

    protected abstract void UpdateInfo();
}