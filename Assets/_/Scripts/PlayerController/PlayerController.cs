using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInputOldSystem), typeof(PlayerMovementSimple))]
public class PlayerController : MonoBehaviour
{
    private IPlayerInput _playerInput;
    private IPlayerMovement _playerMovement;

    private void Awake()
    {
        _playerInput = GetComponent<IPlayerInput>();
        _playerMovement = GetComponent<IPlayerMovement>();
    }

    private void Update()
    {
        if(_playerInput.JumpInput)
            _playerMovement.Jump();
    }
}
