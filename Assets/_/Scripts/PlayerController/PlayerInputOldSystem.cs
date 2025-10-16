using UnityEngine;

public class PlayerInputOldSystem : MonoBehaviour, IPlayerInput
{
    private const string HorizontalName = "Horizontal";
    private const string JumpName = "Jump";
    private const string Vampirism = "Fire1";
    
    public float HorizontalInput => Input.GetAxis(HorizontalName);
    public bool JumpInput => Input.GetButtonDown(JumpName);
    public bool VampirismInput => Input.GetButtonDown(Vampirism);
}
