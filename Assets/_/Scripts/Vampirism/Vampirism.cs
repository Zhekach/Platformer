using UnityEngine;

[RequireComponent(typeof(VampirismDetector), typeof(VampirismTimer))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _healPerSecond;
    [SerializeField] private VampirismDetector _detector;
    [SerializeField] private VampirismTimer _timer;
    
    private void Awake()
    {
        _detector = GetComponent<VampirismDetector>();
        _timer = GetComponent<VampirismTimer>();
    }

    public void Activate()
    {
        _timer.Activate();
    }
}