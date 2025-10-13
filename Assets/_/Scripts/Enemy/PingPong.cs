using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PingPong : MonoBehaviour
{
    [SerializeField] private float _lengthX;
    [SerializeField] private Rigidbody2D _rigidbody;
    
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
        
        Debug.Log(_rigidbody.linearVelocity.x + "   " + _direction );
        
        if (_direction > 0 && transform.position.x >= _startX + _lengthX)
            _direction = -1;
        else if (_direction < 0 && transform.position.x <= _startX - _lengthX)
            _direction = 1;
    }
}