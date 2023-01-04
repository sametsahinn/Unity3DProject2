using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float maxLifeTime = 7f;

    VerticalMover verticalMover;
    float currentTimeLife = 0f;

    public float MoveSpeed => moveSpeed;

    private void Awake()
    {
        verticalMover = new VerticalMover(this);
    }

    private void Update()
    {
        currentTimeLife += Time.deltaTime;

        if (currentTimeLife >= maxLifeTime)
        {
            currentTimeLife = 0f;
            KillEnemy();
        }
    }

    private void FixedUpdate()
    {
        verticalMover.TickFixed();
    }

    void KillEnemy()
    {
        Destroy(this.gameObject);
    }
}
