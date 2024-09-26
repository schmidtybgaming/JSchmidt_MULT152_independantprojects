using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab; // Assign the enemy prefab in the Inspector
    public int maxEnemies = 30; // Maximum number of enemies to spawn
    private int currentEnemyCount = 0;

    void Start()
    {
        // Start invoking the SpawnEnemy method every 1 second
        InvokeRepeating("SpawnEnemy", 1.0f, 1.0f);
    }

    void SpawnEnemy()
    {
        if (currentEnemyCount < maxEnemies)
        {
            // Generate random position within the specified bounds
            float randomX = Random.Range(-158f, 4f);
            float randomY = 3f;
            float randomZ = Random.Range(-70f, 13f);
            Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

            // Instantiate the enemy at the random position
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            currentEnemyCount++;
        }
        else
        {
            // Stop invoking the SpawnEnemy method once the max number of enemies is reached
            CancelInvoke("SpawnEnemy");
        }
    }
    }
