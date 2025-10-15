using UnityEngine;

public class CanvasAnchorToTransform : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _offset;
    

    private void Awake()
    {
        if (_target == null)
        {
            Debug.LogError($"{nameof(CanvasAnchorToTransform)}: Target is not assigned", this);
            enabled = false;
            return;
        }

        _offset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        if (_target == null)
            return;

        transform.position = _target.position + _offset;
    }
}