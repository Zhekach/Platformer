using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class AnimatorAdapter : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovementSimple _playerMovement;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private string _speedParamName = "SpeedAbs";
    [SerializeField] private string _isJumpingParamName = "IsJumping";
    
    private int _speedHash; 
    private int _isJumpingHash; 

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _speedHash = Animator.StringToHash(_speedParamName);
        _isJumpingHash = Animator.StringToHash(_isJumpingParamName);
    }

    public void Update()
    {
        _animator.SetFloat(_speedHash, Mathf.Abs(_playerMovement.Speed));
        _animator.SetBool(_isJumpingHash, !_playerMovement.IsGrounded);
        
        if(_playerMovement.Speed < 0)
            _renderer.flipX = true;
        else if (_playerMovement.Speed > 0)
            _renderer.flipX = false;
    }
}
