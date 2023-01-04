using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 300f;    

    HorizontalMover horizontalMover;
    JumpWithRigidbody jump;
    IInputReader input;

    float horizontal;
    bool isJump;

    private void Awake()
    {
        horizontalMover = new HorizontalMover(this);
        jump = new JumpWithRigidbody(this);
        input = new InputReader(GetComponent<PlayerInput>());
    }

    private void Update()
    {
        horizontal = input.Horizontal;

        if (input.Jump) isJump = true;
    }

    private void FixedUpdate()
    {
        horizontalMover.TickFixed(horizontal, moveSpeed);

        if (isJump)
        {
            jump.TickFixed(jumpForce);            
        }
        isJump = false;
    }
}
