using System;
using UnityEngine;

[RequireComponent(typeof(VampirismDetector), typeof(VampirismTimer))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _healPerSecond;
    [SerializeField] private float _radius;
    [SerializeField] private VampirismDetector _detector;
    [SerializeField] private VampirismTimer _timer;
    [SerializeField] private Health _health;
    
    private void Awake()
    {
        _detector = GetComponent<VampirismDetector>();
        _timer = GetComponent<VampirismTimer>();
        _detector.Initialize(_radius);
    }

    private void FixedUpdate()
    {
        if(_timer.State != VampirismState.Active)
            return;
        
        if(_detector.TryDetectTarget(out Transform targetTransform))
        {
            targetTransform.GetComponent<Health>().TakeDamage(_healPerSecond * Time.fixedDeltaTime);
            _health.Heal(_healPerSecond * Time.fixedDeltaTime);
            Debug.Log($"Vampirism {targetTransform.name}");
        }
    }

    public void Activate()
    {
        _timer.Activate();
    }
    
    
}