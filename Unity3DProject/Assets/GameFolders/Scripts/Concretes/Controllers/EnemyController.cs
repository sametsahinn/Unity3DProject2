using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MyCharacterController, IEntityController
{
    [SerializeField] float maxLifeTime = 7f;
    [SerializeField] EEnemy enemyEnum;

    VerticalMover verticalMover;
    float currentTimeLife = 0f;

    public EEnemy EnemyEnum => enemyEnum;


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
        // Destroy(this.gameObject);
        EnemyManager.Instance.SetPool(this);
    }
}
