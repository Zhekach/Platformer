using System;
using UnityEngine;

[RequireComponent(typeof(VampirismDetector), typeof(VampirismTimer))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _healPerSecond;
    [SerializeField] private float _radius;
    [SerializeField] private VampirismDetector _detector;
    [SerializeField] private VampirismTimer _timer;
    [SerializeField] private VampirismView _view;
    [SerializeField] private VampirismBarIndicator _indicator;
    [SerializeField] private Health _health;

    private void Awake()
    {
        InitializeComponents();
    }

    private void FixedUpdate()
    {
        if (_timer.State != VampirismState.Active)
            return;

        if (_detector.TryDetectTarget(out Transform targetTransform) == false)
            return;
        
        if (targetTransform.TryGetComponent(out Health health))
        {
            health.TakeDamage(_healPerSecond * Time.fixedDeltaTime);
            _health.Heal(_healPerSecond * Time.fixedDeltaTime);
        }
    }

    public void Activate()
    {
        _timer.Activate();
    }

    private void InitializeComponents()
    {
        _detector = GetComponent<VampirismDetector>();
        _timer = GetComponent<VampirismTimer>();

        if (_view == null)
            throw new ArgumentNullException($"Not assigned {nameof(VampirismView)} to {name}");

        if (_indicator == null)
            throw new ArgumentNullException($"Not assigned {nameof(VampirismBarIndicator)} to {name}");

        _detector.Initialize(_radius);
        _view.Initialize(_timer, _radius);
        _indicator.Initialize(_timer);
    }
}