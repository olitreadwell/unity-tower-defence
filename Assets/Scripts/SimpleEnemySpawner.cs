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
        
        if (targetCastle == null)
        {
            Debug.LogError("Target Castle is not assigned in SimpleEnemySpawner.");
        }

        if (targetPath == null)
        {
            Debug.LogError("Target Path is not assigned in SimpleEnemySpawner.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetCastle == null || targetPath == null)
        {
            return; // Cannot proceed without references
        }

        // Check if we have any enemies left to spawn
        if (totalEnemiesToSpawn > 0 && targetCastle.currentHealth > 0)
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
        if (enemyToSpawn == null)
        {
            Debug.LogError("Enemy prefab is not assigned in SimpleEnemySpawner.");
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogError("Spawn Point is not assigned in SimpleEnemySpawner.");
            return;
        }
        
        // Instantiate the enemy at the spawn point with the correct rotation
        EnemyController newEnemy = Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);


        // Spawn an enemy
        Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation).Setup(targetCastle, targetPath);

        // Assign the castle and path to the new enemy
        newEnemy.Setup(targetCastle, targetPath);

        // Reduce the amount of enemies left to spawn
        totalEnemiesToSpawn--;
    }
}
