using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (Player))]

public class PlayerController : MonoBehaviour
{
    private Player player;
    private bool jump;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (!jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }

    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        bool roll = Input.GetKey(KeyCode.X);
        bool run = Input.GetKey(KeyCode.LeftShift);
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        player.Move(h, crouch, roll, jump, run);
        jump = false;
    }
}
