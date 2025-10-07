﻿using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(GroundChecker))]
public class PlayerMovementSimple : MonoBehaviour, IPlayerMovement
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce = 1f;
    [SerializeField] private float _speed = 2f;

    private void Awake()
    {
        _groundChecker = GetComponent<GroundChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalSpeed)
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        velocity.x = _speed * horizontalSpeed;
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
