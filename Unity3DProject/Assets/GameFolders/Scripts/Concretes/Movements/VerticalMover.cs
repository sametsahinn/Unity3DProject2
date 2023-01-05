using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : IMover
{
    IEntityController enemyController;

    public VerticalMover(IEntityController entityController)
    {
        this.enemyController = entityController;
    }

    public void TickFixed(float vertical = 1)
    {
        // Debug.Log(enemyController.MoveSpeed);
        enemyController.transform.Translate(Vector3.back * vertical * Time.deltaTime * enemyController.MoveSpeed);
    }
}
