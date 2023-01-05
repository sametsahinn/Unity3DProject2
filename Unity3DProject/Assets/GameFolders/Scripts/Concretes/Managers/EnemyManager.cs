using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SinglationThisObject<EnemyManager>
{
    [SerializeField] EnemyController[] enemyPreFabs;

    Queue<EnemyController> enemies = new Queue<EnemyController>();

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
        for (int i = 0; i < 10; i++)
        {
            EnemyController newEnemy = Instantiate(enemyPreFabs[Random.Range(0, enemyPreFabs.Length)]);
            newEnemy.gameObject.SetActive(false);
            newEnemy.transform.parent = this.transform;
            enemies.Enqueue(newEnemy);
        }
    }

    public void SetPool(EnemyController enemyController)
    {
        enemyController.gameObject.SetActive(false);
        enemyController.transform.parent = this.transform;
        enemies.Enqueue(enemyController);
    }

    public EnemyController GetPool()
    {
        if (enemies.Count == 0)
        {
            InitiliazePool();
        }

        return enemies.Dequeue();
    }
}
