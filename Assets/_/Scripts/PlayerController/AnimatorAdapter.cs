using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorAdapter : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovementSimple _playerMovement;
    [SerializeField] private string _speedParamName = "SpeedAbs";
    [SerializeField] private string _isJumpingParamName = "IsJumping";
    
    private int _speedHash; 
    private int _isJumpingHash; 

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _speedHash = Animator.StringToHash(_speedParamName);
        _isJumpingHash = Animator.StringToHash(_isJumpingParamName);
    }

    public void Update()
    {
        _animator.SetFloat(_speedHash, Mathf.Abs(_playerMovement.Speed));
        _animator.SetBool(_isJumpingHash, !_playerMovement.IsGrounded);
    }
}
