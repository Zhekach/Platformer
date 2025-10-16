using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VampirismBarIndicator : MonoBehaviour
{
    [SerializeField] private VampirismTimer _timer;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

    }
    
    public void Initialize(VampirismTimer timer)
    {
        _timer = timer;
    }
    
    private void Update()
    {
        switch (_timer.State)
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