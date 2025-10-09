public interface IPlayerMovement
{
    void Move(float horizontalSpeed);
    void Jump();
    
    float Speed { get; }
    bool IsGrounded { get; }
    bool IsRightWallTouched { get; }
    bool IsLeftWallTouched { get; }
}