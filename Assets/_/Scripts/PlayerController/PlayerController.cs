using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInputOldSystem), typeof(PlayerMovementSimple), typeof(AnimatorAdapter))]
public class PlayerController : MonoBehaviour
{
    private IPlayerInput _playerInput;
    private IPlayerMovement _playerMovement;
    private AnimatorAdapter _animatorAdapter;

    private void Awake()
    {
        _playerInput = GetComponent<IPlayerInput>();
        _playerMovement = GetComponent<IPlayerMovement>();
        _animatorAdapter = GetComponent<AnimatorAdapter>();
    }

    private void Update()
    {
        _playerMovement.Move(_playerInput.HorizontalInput);

        if (_playerInput.JumpInput)
            _playerMovement.Jump();
    }
}