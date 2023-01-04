using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveBoundary = 4.5f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 300f;    

    HorizontalMover horizontalMover;
    JumpWithRigidbody jump;
    IInputReader input;

    float horizontal;
    bool isJump;
    bool isDead = false;

    public float MoveSpeed => moveSpeed;
    public float MoveBoundary => moveBoundary;

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
        EnemyController enemyController = other.GetComponent<EnemyController>();

        if (enemyController != null)
        {
            isDead = true;
            GameManager.Instance.GameOver();            
        }
    }
}
