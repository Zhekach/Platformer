using System;
using UnityEngine;

[Serializable]
public class PlayerInputOldSystem : MonoBehaviour, IPlayerInput
{
    public float HorizontalInput => Input.GetAxis("Horizontal");
    public bool JumpInput => Input.GetButton("Jump");
}
