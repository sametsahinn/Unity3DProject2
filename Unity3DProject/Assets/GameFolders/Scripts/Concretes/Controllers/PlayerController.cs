using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MyCharacterController, IEntityController
{
    [SerializeField] float jumpForce = 300f;    

    IMover horizontalMover;
    IJump jump;
    IInputReader input;

    float horizontal;
    bool isJump;
    bool isDead = false;    

    private void Awake()
    {
        horizontalMover = new HorizontalMover(this);
        jump = new JumpWithRigidbody(this);
        input = new InputReader(GetComponent<PlayerInput>());
    }

    private void Update()
    {
        if (isDead) return;
        horizontal = input.Horizontal;

        if (input.Jump) isJump = true;
    }

    private void FixedUpdate()
    {
        horizontalMover.TickFixed(horizontal);

        if (isJump)
        {
            jump.TickFixed(jumpForce);            
        }
        isJump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        IEntityController entityController = other.GetComponent<IEntityController>();

        if (entityController != null)
        {
            isDead = true;
            GameManager.Instance.GameOver();            
        }
    }
}
