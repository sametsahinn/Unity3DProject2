using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWithRigidbody
{
    Rigidbody rigidbody;

    public bool CanJump => rigidbody.velocity.y != 0f;

    public JumpWithRigidbody(PlayerController playerController)
    {
        this.rigidbody = playerController.GetComponent<Rigidbody>();
    }

    public void TickFixed(float jumpForece)
    {
        if (CanJump) return;

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(Vector3.up * Time.deltaTime * jumpForece);
    }
}
