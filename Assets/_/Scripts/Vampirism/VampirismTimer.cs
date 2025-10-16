using System.Collections;
using UnityEngine;

public class VampirismTimer : MonoBehaviour
{
    [SerializeField] private float _activeTime = 6f;
    [SerializeField] private float _cooldownTime = 4f;
    [SerializeField] private VampirismState _state = VampirismState.Ready;

    private Coroutine _coroutine;
    
    public VampirismState State => _state;

    public void Activate()
    {
        if(_state != VampirismState.Ready)
            return;
        
        _state = VampirismState.Active;
        _coroutine = StartCoroutine(ActiveTimer());
    }
    
    private IEnumerator ActiveTimer()
    {
        yield return new WaitForSeconds(_activeTime);
        _state = VampirismState.Cooldown;
        
        _coroutine = null;
        _coroutine = StartCoroutine(CooldownTimer());
    }
    
    private IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(_cooldownTime);
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