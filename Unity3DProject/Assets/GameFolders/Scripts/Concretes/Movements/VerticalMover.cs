using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : IMover
{
    IEntityController enemyController;

    float moveSpeed;

    public VerticalMover(IEntityController entityController)
    {
        this.enemyController = entityController;
        this.moveSpeed = entityController.MoveSpeed;
    }

    public void TickFixed(float vertical = 1)
    {
        enemyController.transform.Translate(Vector3.back * vertical * Time.deltaTime * moveSpeed);
    }
}
