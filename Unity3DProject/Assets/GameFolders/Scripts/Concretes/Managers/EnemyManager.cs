using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SinglationThisObject<EnemyManager>
{
    [SerializeField] float addDelayTime = 50f;

    [SerializeField] EnemyController[] enemyPreFabs;

    Dictionary<EEnemy, Queue<EnemyController>> dicEnemies = new Dictionary<EEnemy, Queue<EnemyController>>();

    public float AddDelayTime => addDelayTime;
    public float Count => enemyPreFabs.Length;


    private void Awake()
    {
        SingletonThisGameObject(this);
    }

    private void Start()
    {
        InitiliazePool();
    }

    private void InitiliazePool()
    {
        for (int i = 0; i < enemyPreFabs.Length; i++)
        {
            Queue<EnemyController> enemies = new Queue<EnemyController>();

            for (int j = 0; j < 10; j++)
            {
                EnemyController newEnemy = Instantiate(enemyPreFabs[i]);
                newEnemy.gameObject.SetActive(false);
                newEnemy.transform.parent = this.transform;
                enemies.Enqueue(newEnemy);                
            }

            dicEnemies.Add((EEnemy)i, enemies);
        }
    }

    public void SetPool(EnemyController enemyController)
    {
        enemyController.gameObject.SetActive(false);
        enemyController.transform.parent = this.transform;

        Queue<EnemyController> enemy = dicEnemies[enemyController.EnemyEnum];
        enemy.Enqueue(enemyController);
    }

    public EnemyController GetPool(EEnemy enemyType)
    {
        Queue<EnemyController> enemy = dicEnemies[enemyType];

        if (enemy.Count == 0)
        {
            // InitiliazePool();

            for (int i = 0; i < 2; i++)
            {
                EnemyController newEnemy = Instantiate(enemyPreFabs[(int)enemyType]);
                enemy.Enqueue(newEnemy);
            }            
        }

        return enemy.Dequeue();
    }
}
