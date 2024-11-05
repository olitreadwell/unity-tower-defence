using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    
    public EnemyController enemyToSpawn;
    public Transform spawnPoint;
    public float timeBetweenSpawns = 1f;
    private float spawnCounter;
    public int amountToSpawn = 15;
    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if we have any enemies left to spawn
        if (amountToSpawn > 0)
        {
            // Count down the spawn counter
            spawnCounter -= Time.deltaTime;

            // Check if it is time to spawn an enemy
            if (spawnCounter <= 0)
            {
                // Reset the spawn counter
                spawnCounter = timeBetweenSpawns;

                // Spawn an enemy
                SpawnEnemy();

            }
        }
    }

    private void SpawnEnemy()
    {
        // Spawn an enemy
        EnemyController newEnemy = Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);

        // Reduce the amount of enemies left to spawn
        amountToSpawn--;
    }
}
