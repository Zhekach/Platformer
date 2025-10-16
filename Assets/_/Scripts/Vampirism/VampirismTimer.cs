using System;
using System.Collections;
using UnityEngine;

public class VampirismTimer : MonoBehaviour
{
    [SerializeField] private float _activeTimeMax = 6f;
    [SerializeField] private float _cooldownTimeMax = 4f;
    [SerializeField] private VampirismState _state;

    private Coroutine _coroutine;
    private float _activeTimeLeft;
    private float _cooldownTimeLeft;

    public event Action StateChanged;
    
    public VampirismState State => _state;
    public float ActiveTimeMax => _activeTimeMax;
    public float ActiveTimeLeft => _activeTimeLeft;
    public float CooldownTimeMax => _cooldownTimeMax;
    public float CooldownTimeLeft => _cooldownTimeLeft;

    private void Start()
    {
        _state = VampirismState.Ready;
    }

    public void Activate()
    {
        if (_state != VampirismState.Ready)
            return;

        ChangeState(VampirismState.Active);
        _activeTimeLeft = _activeTimeMax;
        _coroutine = StartCoroutine(ActiveTimer());
    }

    private IEnumerator ActiveTimer()
    {
        while (_activeTimeLeft > 0)
        {
            _activeTimeLeft -= Time.deltaTime;
            yield return null;
        }

        ChangeState(VampirismState.Cooldown);
        _cooldownTimeLeft = _cooldownTimeMax;
        _coroutine = StartCoroutine(CooldownTimer());
    }

    private IEnumerator CooldownTimer()
    {
        while (_cooldownTimeLeft > 0)
        {
            _cooldownTimeLeft -= Time.deltaTime;
            yield return null;
        }

        ChangeState(VampirismState.Ready);
        _coroutine = null;
    }
    
    private void ChangeState(VampirismState newState)
    {
        _state = newState;
        StateChanged?.Invoke();
    }
}

public enum VampirismState
{
    Active,
    Cooldown,
    Ready
}