using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : IMover
{
    IEntityController playerController;
    float moveSpeed;
    float moveBoundary;

    public HorizontalMover(IEntityController entityController)
    {
        this.playerController = entityController;
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
