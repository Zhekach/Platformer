using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SimpleBarIndicator : HealthIndicator
{
    [FormerlySerializedAs("_slider")] [SerializeField] protected Slider Slider;

    protected override void Start()
    {
        base.Start();
        Slider.maxValue = Health.MaxHealth;
    }
    
    protected override void UpdateInfo()
    {
        Slider.value = Health.CurrentValue;

        Slider.fillRect.gameObject.SetActive(Slider.value != 0);
    }
}