using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Vector2 _offset = new Vector2(0f, -1f);
    [SerializeField] private float _radius = 0.1f;

    [Header("Debug")] 
    [SerializeField] private bool _drawGizmos;

    private Vector3 _offset3D;
    
    public bool IsGrounded => CheckGrounded();

    private void Awake()
    {
        _offset3D = new Vector3(_offset.x, _offset.y, 0);
    }

    private bool CheckGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position + _offset3D, _radius);
        
        return collider.TryGetComponent<Ground>(out _);
    }
    
    private void OnDrawGizmosSelected()
    {
        if (!_drawGizmos)
            return;

        Vector2 checkPosition = (Vector2)transform.position + _offset;
        Gizmos.color = IsGrounded ? Color.green : Color.red;

        DrawCapsuleGizmo(checkPosition, _radius);
    }

    private void DrawCapsuleGizmo(Vector2 center, float radius)
    {
        Gizmos.DrawWireSphere(center, radius);
    }
}