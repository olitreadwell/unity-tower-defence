using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{

    [Header("Enemy Settings")]    
    public EnemyController enemyToSpawn;
    public Transform spawnPoint;
    public int totalEnemiesToSpawn = 15;

    [Header("Spawn Timing")]
    public float timeBetweenSpawns = 1f;
    private float spawnTimer;

    [Header("Target GameObjects")]
    public Castle targetCastle;
    public Path targetPath;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if we have any enemies left to spawn
        if (totalEnemiesToSpawn > 0)
        {
            // Count down the spawn counter
            spawnTimer -= Time.deltaTime;

            // Check if it is time to spawn an enemy
            if (spawnTimer <= 0)
            {
                // Spawn an enemy
                SpawnEnemy();

                // Reset the spawn counter
                spawnTimer = timeBetweenSpawns;
            }
        }
    }


    // Function to spawn an enemy
    private void SpawnEnemy()
    {
        // Spawn an enemy
        Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation).Setup(targetCastle, targetPath);

        // Reduce the amount of enemies left to spawn
        totalEnemiesToSpawn--;
    }
}
