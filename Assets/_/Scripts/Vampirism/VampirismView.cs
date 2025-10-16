using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VampirismView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _cooldownColor;
    [SerializeField] private Color _readyColor;

    private VampirismTimer _timer;
    private float _radius;

    private void Awake()
    {
        if(_spriteRenderer == null)
            throw new ArgumentNullException($"Not assigned {nameof(SpriteRenderer)} to {name}");
    }

    private void Update()
    {
        SetState();
    }

    public void Initialize(VampirismTimer timer, float radius)
    {
        _timer = timer;
        _radius = radius;
        _spriteRenderer.transform.localScale = new Vector3(_radius * 2f, _radius * 2f, 1f);
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