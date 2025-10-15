using System.Collections;
using UnityEngine;

public class SmoothBarIndicator : SimpleBarIndicator
{
    [SerializeField] private float _smoothDelta = 0.05f;

    private Coroutine _coroutine;

    protected override void UpdateInfo()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SmoothUpdate());
    }

    private IEnumerator SmoothUpdate()
    {
        while (Mathf.Approximately(Slider.value, Health.CurrentValue) == false)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, Health.CurrentValue, _smoothDelta);
            Slider.fillRect.gameObject.SetActive(Slider.value != 0);

            yield return null;
        }
    }
}