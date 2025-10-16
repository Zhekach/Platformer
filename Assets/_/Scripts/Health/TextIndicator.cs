using TMPro;
using UnityEngine;

public class TextIndicator : HealthIndicator
{
    [SerializeField] private TMP_Text _text;

    protected override void UpdateInfo()
    {
        _text.text = (int)Health.Current + "/" + (int)Health.Max;
    }
}