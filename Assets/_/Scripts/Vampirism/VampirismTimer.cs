using System.Collections;
using UnityEngine;

public class VampirismTimer : MonoBehaviour
{
    [SerializeField] private float _activeMaxTime = 6f;
    [SerializeField] private float _cooldownMaxTime = 4f;
    [SerializeField] private VampirismState _state;

    private Coroutine _coroutine;
    
    public VampirismState State => _state;

    private void Start()
    {
        _state = VampirismState.Ready;
    }
    
    public void Activate()
    {
        if(_state != VampirismState.Ready)
            return;
        
        _state = VampirismState.Active;
        _coroutine = StartCoroutine(ActiveTimer());
    }
    
    private IEnumerator ActiveTimer()
    {
        yield return new WaitForSeconds(_activeMaxTime);
        _state = VampirismState.Cooldown;
        
        _coroutine = null;
        _coroutine = StartCoroutine(CooldownTimer());
    }
    
    private IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(_cooldownMaxTime);
        _state = VampirismState.Ready;
        
        _coroutine = null;
    }
}

public enum VampirismState
{
    Active,
    Cooldown,
    Ready
}