using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VampirismView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _cooldownColor;
    [SerializeField] private Color _readyColor;

    private VampirismTimer _timer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        _timer.StateChanged -= SetState;
    }

    public void Initialize(VampirismTimer timer, float radius)
    {
        _timer = timer;
        _timer.StateChanged += SetState;
        _spriteRenderer.transform.localScale = new Vector3(radius * 2f, radius * 2f, 1f);
    }

    private void SetState()
    {
        VampirismState state = _timer.State;
        
        switch (state)
        {
            case VampirismState.Ready:
                _spriteRenderer.color = _readyColor;
                break;
            case VampirismState.Cooldown:
                _spriteRenderer.color = _cooldownColor;
                break;
            case VampirismState.Active:
                _spriteRenderer.color = _activeColor;
                break;
        }
    }
}