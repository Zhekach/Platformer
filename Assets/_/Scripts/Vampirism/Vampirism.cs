using System;
using UnityEngine;

[RequireComponent(typeof(VampirismTimer))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _healPerSecond;
    [SerializeField] private float _radius;
    [SerializeField] private VampirismTimer _timer;
    [SerializeField] private VampirismBarIndicator _indicator;
    [SerializeField] private Health _health;
    
    private VampirismDetector _detector;
    private VampirismState _state;
    
    public event Action StateChanged;
    
    public VampirismState State => _state;
    public VampirismTimer Timer => _timer;
    public float Radius => _radius;
    
    private void Awake()
    {
        _timer = GetComponent<VampirismTimer>();
        _detector = new VampirismDetector(_radius);
        _state = VampirismState.Ready;
    }

    private void Update()
    {
        ReleaseVampirism();
    }

    public void ChangeState(VampirismState state)
    {
        _state = state;
        StateChanged?.Invoke();
    } 
    
    public void Activate()
    {
        _timer.Activate();
    }

    private void ReleaseVampirism()
    {
        if (_state != VampirismState.Active)
            return;

        if (_detector.TryDetectTarget(transform, out Transform targetTransform) == false)
            return;
        
        if (targetTransform.TryGetComponent(out Health health))
        {
            health.TakeDamage(_healPerSecond * Time.deltaTime);
            _health.Heal(_healPerSecond * Time.deltaTime);
        }
    }
}