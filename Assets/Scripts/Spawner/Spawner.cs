using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int maxSpawnedEnemies;
    [SerializeField] private float spawnSpeed;

    private int currentSpawnedEnemies;
    private bool maySpawn = true;

    private void Update()
    {
        if (maySpawn && maxSpawnedEnemies > currentSpawnedEnemies)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator SpawnEnemy()
    {
        maySpawn = false;
        yield return new WaitForSeconds(spawnSpeed);
        var newEnemy = Instantiate(enemyPrefab, transform.position, quaternion.identity);
        newEnemy.GetComponent<Health>().OnDeath += EnemyDied;
        currentSpawnedEnemies++;
        maySpawn = true;
    }

    private void EnemyDied()
    {
        currentSpawnedEnemies--;
    }
}
