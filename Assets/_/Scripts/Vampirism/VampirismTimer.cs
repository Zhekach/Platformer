using System;
using System.Collections;
using UnityEngine;

public class VampirismTimer : MonoBehaviour
{
    [SerializeField] private float _activeTimeMax = 6f;
    [SerializeField] private float _cooldownTimeMax = 4f;
    [SerializeField] private VampirismState _state;

    private Coroutine _coroutine;
    private WaitForSeconds _activeWait;
    private WaitForSeconds _cooldownWait;
    private float _activeTimeLeft;
    private float _cooldownTimeLeft;

    public VampirismState State => _state;
    public float ActiveTimeMax => _activeTimeMax;
    public float ActiveTimeLeft => _activeTimeLeft;
    public float CooldownTimeMax => _cooldownTimeMax;
    public float CooldownTimeLeft => _cooldownTimeLeft;

    private void Start()
    {
        _state = VampirismState.Ready;
        _activeWait = new WaitForSeconds(_activeTimeMax);
        _cooldownWait = new WaitForSeconds(_cooldownTimeMax);
    }

    private void Update()
    {
        if (_coroutine != null)
            return;

        if (_state == VampirismState.Cooldown )
        {
            _cooldownTimeLeft = _cooldownTimeMax;
            _coroutine = StartCoroutine(CooldownTimer());
        }
    }

    public void Activate()
    {
        if (_state != VampirismState.Ready)
            return;

        _state = VampirismState.Active;
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

        _state = VampirismState.Cooldown;
        _coroutine = null;
    }

    private IEnumerator CooldownTimer()
    {
        while (_cooldownTimeLeft > 0)
        {
            _cooldownTimeLeft -= Time.deltaTime;
            yield return null;
        }

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