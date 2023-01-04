using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : MonoBehaviour
{
    EnemyController enemyController;

    public VerticalMover(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void TickFixed(float vertical = 1)
    {
        enemyController.transform.Translate(Vector3.back * vertical * Time.deltaTime * enemyController.MoveSpeed);
    }
}
