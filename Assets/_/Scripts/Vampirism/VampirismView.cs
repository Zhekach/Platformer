using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VampirismView : MonoBehaviour
{
    [SerializeField] private Vampirism _model;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _cooldownColor;
    [SerializeField] private Color _readyColor;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_model == null)
            throw new ArgumentNullException($"Not assigned {nameof(Vampirism)} to {name}");

        _spriteRenderer.transform.localScale = new Vector3(_model.Radius * 2f, _model.Radius * 2f, 1f);
    }

    private void OnEnable()
    {
        _model.StateChanged += SetState;
    }

    private void OnDisable()
    {
        _model.StateChanged -= SetState;
    }

    private void SetState()
    {
        VampirismState state = _model.State;

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