using UnityEngine;

[RequireComponent(typeof(PlayerInputOldSystem), typeof(PlayerMovementSimple), typeof(AnimatorAdapter))]
[RequireComponent(typeof(Vampirism))]
public class PlayerRoot : MonoBehaviour
{
    private IPlayerInput _playerInput;
    private IPlayerMovement _playerMovement;
    private AnimatorAdapter _animatorAdapter;
    private Vampirism _vampirism;

    private void Awake()
    {
        _playerInput = GetComponent<IPlayerInput>();
        _playerMovement = GetComponent<IPlayerMovement>();
        _animatorAdapter = GetComponent<AnimatorAdapter>();
        _vampirism = GetComponent<Vampirism>();
    }

    private void Update()
    {
        UpdateMovement();
        UpdateAnimation();
        UpdateAttack();
    }
    
    private void UpdateMovement()
    {
        _playerMovement.Move(_playerInput.HorizontalInput);

        if (_playerInput.JumpInput)
            _playerMovement.Jump();
    }

    private void UpdateAnimation()
    {
        _animatorAdapter.SetMovementAnimation(_playerMovement.Speed);
        _animatorAdapter.SetJumpAnimation(_playerMovement.IsGrounded);
    }
    
    private void UpdateAttack()
    {
        if (_playerInput.VampirismInput)
            _vampirism.Activate();
    }
}