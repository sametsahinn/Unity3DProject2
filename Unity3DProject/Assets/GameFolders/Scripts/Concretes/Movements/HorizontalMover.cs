using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover
{
    PlayerController playerController;

    public HorizontalMover(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void TickFixed(float horizontal, float moveSpeed)
    {
        if (horizontal == 0f) return;

        playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * moveSpeed);
    }
}
