using UnityEngine;

public class PlayerInputOldSystem : MonoBehaviour, IPlayerInput
{
    public float HorizontalInput => Input.GetAxis("Horizontal");
    public bool JumpInput => Input.GetButtonDown("Jump");
}
