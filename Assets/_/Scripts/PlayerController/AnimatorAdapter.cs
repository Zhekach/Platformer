using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMovementSimple))]
public class AnimatorAdapter : MonoBehaviour
{
    private const float SpeedDeltaMin = 0.01f;
    
    [SerializeField] private Animator _animator;
    [SerializeField] private IPlayerMovement _playerMovement;
    [SerializeField] private string _speedParamName = "SpeedAbs";
    [SerializeField] private string _isJumpingParamName = "IsJumping";
    
    private int _speedHash; 
    private int _isJumpingHash;

    private float _lastSpeedAbs;
    private bool _lastIsGrounded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<IPlayerMovement>();
        _speedHash = Animator.StringToHash(_speedParamName);
        _isJumpingHash = Animator.StringToHash(_isJumpingParamName);
    }

    public void Update()
    {
        SetMovementAnimation(_playerMovement.Speed);
        SetJumpAnimation(_playerMovement.IsGrounded);
    }

    private void SetMovementAnimation(float speed)
    {
        float speedAbs = Mathf.Abs(speed);
        
        if (speedAbs < SpeedDeltaMin)
            speedAbs = 0f;
        
        if(Mathf.Approximately(speedAbs, _lastSpeedAbs))
            return;
        
        _animator.SetFloat(_speedHash, speedAbs);
        _lastSpeedAbs = speedAbs;
    }

    private void SetJumpAnimation(bool isGrounded)
    {
        if(isGrounded == _lastIsGrounded)
            return;
        
        _animator.SetBool(_isJumpingHash, !isGrounded);
        _lastIsGrounded = isGrounded;
    }
}
