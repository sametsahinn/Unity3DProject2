using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] EnemyController enemyPreFabs;

    [Range(0.1f, 5f)]
    [SerializeField] float min = 0.1f;

    [Range(6f, 15f)]
    [SerializeField] float max = 15f;

    float maxSpawnTime;

    float currentSpawnTime = 0f;

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
    }

    void Spawn()
    {
        EnemyController newEnemy = Instantiate(enemyPreFabs, transform.position, transform.rotation);
        newEnemy.transform.parent = this.transform;

        currentSpawnTime = 0f;
        GetRandomMaxTime();
    }

    void GetRandomMaxTime()
    {
        maxSpawnTime = Random.Range(min, max);
    }
}
