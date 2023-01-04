using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horizontalDirection = 0f;
    [SerializeField] float moveSpeed = 10f; 

    HorizontalMover horizontalMover;

    private void Awake()
    {
        horizontalMover = new HorizontalMover(this);
    }

    private void FixedUpdate()
    {
        horizontalMover.TickFixed(horizontalDirection, moveSpeed);
    }
}
