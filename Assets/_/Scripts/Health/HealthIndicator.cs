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
        Health.OnHealthChanged += UpdateInfo;
    }
    
    protected void OnDisable()
    {
        Health.OnHealthChanged -= UpdateInfo;
    }

    protected abstract void UpdateInfo();
}