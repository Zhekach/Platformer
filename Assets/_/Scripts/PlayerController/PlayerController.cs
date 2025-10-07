using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInputOldSystem))]
public class PlayerController : MonoBehaviour
{
    private IPlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<IPlayerInput>();
    }

    private void Update()
    {
        
    }
}
