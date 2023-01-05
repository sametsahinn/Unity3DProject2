using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [Range(0.1f, 5f)]
    [SerializeField] float min = 0.1f;

    [Range(6f, 15f)]
    [SerializeField] float max = 15f;

    public bool CanIncrease => index < EnemyManager.Instance.Count;

    float maxSpawnTime;

    float currentSpawnTime = 0f;


    int index = 0;
    float maxAddEnemyTime;

    private void OnEnable()
    {
        GetRandomMaxTime();
    }

    private void Update()
    {
        currentSpawnTime += Time.deltaTime;

        if (currentSpawnTime > maxSpawnTime)
        {
            Spawn();
        }

        if (!CanIncrease) return;

        if (maxAddEnemyTime < Time.time)
        {
            maxAddEnemyTime = Time.time * EnemyManager.Instance.AddDelayTime;
            IncreaseIndex();
        }
    }

    void Spawn()
    {

        EnemyController newEnemy = EnemyManager.Instance.GetPool((EEnemy)Random.Range(0, index));

        if (newEnemy == null) return;

        newEnemy.transform.parent = this.transform;
        newEnemy.transform.position = transform.transform.position;
        newEnemy.gameObject.SetActive(true);

        currentSpawnTime = 0f;
        GetRandomMaxTime();
    }

    void GetRandomMaxTime()
    {
        maxSpawnTime = Random.Range(min, max);
    }

    void IncreaseIndex()
    {
        if (CanIncrease)
        {
            index++;
        }
    }
}
