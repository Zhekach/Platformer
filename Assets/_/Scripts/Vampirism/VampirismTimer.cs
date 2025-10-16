using System.Collections;
using UnityEngine;

public class VampirismTimer : MonoBehaviour
{
    [SerializeField] private Vampirism _model;
    [SerializeField] private float _activeTimeMax = 6f;
    [SerializeField] private float _cooldownTimeMax = 4f;

    private Coroutine _coroutine;
    private float _activeTimeLeft;
    private float _cooldownTimeLeft;

    public float ActiveTimeMax => _activeTimeMax;
    public float ActiveTimeLeft => _activeTimeLeft;
    public float CooldownTimeMax => _cooldownTimeMax;
    public float CooldownTimeLeft => _cooldownTimeLeft;
    

    public void Activate()
    {
        if (_model.State != VampirismState.Ready)
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
        _model.ChangeState(newState);
    }
}