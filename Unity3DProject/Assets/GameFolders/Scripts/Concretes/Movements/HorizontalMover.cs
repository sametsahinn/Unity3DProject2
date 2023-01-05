using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : IMover
{
    IEntityController playerController;

    public HorizontalMover(IEntityController entityController)
    {
        this.playerController = entityController;
    }

    public void TickFixed(float horizontal)
    {
        if (horizontal == 0f) return;

        playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * playerController.MoveSpeed);

        float xBoundary = Mathf.Clamp(playerController.transform.position.x, -playerController.MoveBoundary, playerController.MoveBoundary);
        playerController.transform.position = new Vector3(xBoundary, playerController.transform.position.y, 0f);
    }
}
