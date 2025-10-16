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
}