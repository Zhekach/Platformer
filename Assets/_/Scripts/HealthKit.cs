using UnityEngine;

public class HealthKit : MonoBehaviour
{
    [SerializeField] private float _healAmount = 10f;
    
    public float HealAmount => _healAmount;
}
