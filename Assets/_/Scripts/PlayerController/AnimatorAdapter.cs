using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMovementSimple))]
public class AnimatorAdapter : MonoBehaviour
{
    private const float SpeedDeltaMin = 0.01f;
    
    [SerializeField] private Animator _animator;
    private IPlayerMovement _playerMovement;
    
    private readonly int Speed = Animator.StringToHash(nameof(Speed));
    private readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));
    
    private float _lastSpeedAbs;
    private bool _lastIsGrounded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<IPlayerMovement>();
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
        
        _animator.SetFloat(Speed, speedAbs);
        _lastSpeedAbs = speedAbs;
    }

    private void SetJumpAnimation(bool isGrounded)
    {
        if(isGrounded == _lastIsGrounded)
            return;
        
        _animator.SetBool(IsJumping, !isGrounded);
        _lastIsGrounded = isGrounded;
    }
}