using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PingPong : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _lengthX;
    
    private float _speed;
    private float _startX;
    private int _direction = 1;
    private bool _isMoving;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startX = transform.position.x;
    }

    public void Initialize(float speed)
    {
        _speed = speed;
    }

    private void FixedUpdate()
    {
        if(_isMoving == false)
            return;
        
        Move();
    }

    public void StartMoving()
    {
        _isMoving = true;
    }

    public void StopMoving()
    {
        _isMoving = false;
    }

    private void Move()
    {
        _rigidbody.linearVelocity = new Vector2(_direction * _speed, _rigidbody.linearVelocity.y);
        
        if (_direction > 0 && transform.position.x >= _startX + _lengthX)
            _direction = -1;
        else if (_direction < 0 && transform.position.x <= _startX - _lengthX)
            _direction = 1;
    }
}