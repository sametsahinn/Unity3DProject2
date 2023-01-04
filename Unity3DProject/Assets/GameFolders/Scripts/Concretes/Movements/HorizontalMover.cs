using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover
{
    PlayerController playerController;
    float moveSpeed;
    float moveBoundary;

    public HorizontalMover(PlayerController playerController)
    {
        this.playerController = playerController;
        this.moveSpeed = playerController.MoveSpeed;
        this.moveBoundary = playerController.MoveBoundary;
    }

    public void TickFixed(float horizontal)
    {
        if (horizontal == 0f) return;

        playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * moveSpeed);

        float xBoundary = Mathf.Clamp(playerController.transform.position.x, -moveBoundary, moveBoundary);
        playerController.transform.position = new Vector3(xBoundary, playerController.transform.position.y, 0f);
    }
}
