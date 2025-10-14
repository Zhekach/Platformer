using UnityEngine;

public class PlayerInputOldSystem : MonoBehaviour, IPlayerInput
{
    private const string HorizontalName = "Horizontal";
    private const string JumpName = "Jump";
    
    public float HorizontalInput => Input.GetAxis(HorizontalName);
    public bool JumpInput => Input.GetButtonDown(JumpName);
}
