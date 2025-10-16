using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VampirismBarIndicator : MonoBehaviour
{
    [SerializeField] private Vampirism _model;
    [SerializeField] private Slider _slider;

    private VampirismTimer _timer;
    
    private void Awake()
    {
        if (_model == null)
            throw new ArgumentNullException($"Not assigned {nameof(Vampirism)} to {name}");
        
        if (_slider == null)
            throw new ArgumentNullException($"Not assigned {nameof(Slider)} to {name}");
        
        _timer = _model.Timer;
    }
    
    private void Update()
    {
        switch (_model.State)
        {
            case(VampirismState.Ready):
                SetReadyIndication();        
                break;
            case(VampirismState.Cooldown):
                SetCooldownIndication();
                break;
            case(VampirismState.Active):
                SetActiveIndication();
                break;
        }
            
        _slider.fillRect.gameObject.SetActive(_slider.value != 0);
    }

    private void SetActiveIndication()
    {
        _slider.value = _timer.ActiveTimeLeft / _timer.ActiveTimeMax * _slider.maxValue;
    }

    private void SetCooldownIndication()
    {
        _slider.value = _slider.maxValue - _timer.CooldownTimeLeft / _timer.CooldownTimeMax * _slider.maxValue;
    }

    private void SetReadyIndication()
    {
        _slider.value = _slider.maxValue;
    }
}