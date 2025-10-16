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
        Health.ChangedValue += UpdateInfo;
    }
    
    protected void OnDisable()
    {
        Health.ChangedValue -= UpdateInfo;
    }

    protected abstract void UpdateInfo();
}