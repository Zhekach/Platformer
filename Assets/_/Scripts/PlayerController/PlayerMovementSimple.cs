using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(GroundChecker))]
public class PlayerMovementSimple : MonoBehaviour, IPlayerMovement
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce = 1.5f;
    [SerializeField] private float _speedMax = 5f;

    private float _currentSpeed;
    
    public bool IsGrounded => _groundChecker.IsGrounded;

    public float Speed => _currentSpeed;

    private void Awake()
    {
        _groundChecker = GetComponent<GroundChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalSpeed)
    {
        _currentSpeed = horizontalSpeed;
        Vector2 velocity = _rigidbody.linearVelocity;
        velocity.x = _speedMax * horizontalSpeed;
        _rigidbody.linearVelocity = velocity;
    }

    public void Jump()
    {
        if (_groundChecker.IsGrounded == false)
            return;

        Vector2 velocity = _rigidbody.linearVelocity;
        velocity.y += _jumpForce;
        _rigidbody.linearVelocity = velocity;
    }
}
