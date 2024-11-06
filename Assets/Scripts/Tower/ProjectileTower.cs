using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{
    private Quaternion targetRotation;

    private Tower targetTower;

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float intervalBetweenShots = 0.5f; // 1 shot per second
    private float shotTimer;

    private Transform target;

    public Transform launcherModel;

    public GameObject shotEffectPrefab;



    // Start is called before the first frame update
    void Start()
    {
        GetTower();
        shotTimer = intervalBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        ShootProjectile();
    }

    private void GetTower()
    {
        targetTower = GetComponent<Tower>();
        if (targetTower == null)
        {
            // Debug.LogError("Tower component not found on the GameObject.");
        }
    }

    private void FindClosestEnemy()
    {
        // Check if there are any enemies in range
        if (targetTower?.enemiesUpdated == false)
        {
            // Debug.Log("No enemies in range");
            return;
        }

        // Check if there are any enemies in range
        if (targetTower?.enemiesInRange?.Count <= 0)
        {
            // Debug.Log("No enemies in range");
            return;
        }

        float shortestDistance = targetTower.attackRange;
        Transform closestEnemy = null;

        // Loop through all enemies in range
        foreach (EnemyController enemy in targetTower.enemiesInRange)
        {
            // Check if the enemy is null
            if (enemy == null)
            {
                // Debug.LogError("EnemyController not found on target");
                return;
            }

            // Calculate the distance to the enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            // Check if the enemy is within range
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;

                // Set the closest enemy as the target
                closestEnemy = enemy.transform;
            }
        }

        // Set the closest enemy as the target
        target = closestEnemy;

        if (target == null)
        {
            // Debug.Log("No target found after checking all enemies in range");
        }
    }
    private void ShootProjectile()
    {
        shotTimer -= Time.deltaTime;

        // Check if it is time to shoot
        if (shotTimer > 0)
        {
            // Debug.Log("Not time to shoot yet");
            return;
        }

        FindClosestEnemy();

        // Check if we have a target
        if (target == null)
        {
            // Debug.Log("No target found");
            return;
        }

        // Check if there are any enemies in range
        if (targetTower.enemiesInRange.Count == 0)
        {
            // Debug.Log("No enemies in range");
            return;
        }

        // Reset the shot timer
        shotTimer = intervalBetweenShots;

        // Aim at the target
        AimAtClosestEnemy();

        projectileSpawnPoint.LookAt(target);

        // Create a new projectile
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        GameObject newShotEffect = Instantiate(shotEffectPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        float shortestDistance = targetTower.attackRange;
        foreach (EnemyController enemy in targetTower.enemiesInRange)
        {
            // Check if the enemy is null
            if (enemy == null)
            {
                // Debug.LogError("EnemyController not found on target");
                return;
            }

            // Calculate the distance to the enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            // Check if the enemy is within range
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;

                // Set the closest enemy as the target
                target = enemy.transform;
            }
        }
    }

    private void AimAtClosestEnemy()
    {
        if (target == null)
        {
            // Debug.Log("No target found");
            return;
        }

        // Rotate the launcher towards the target
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        launcherModel.rotation = Quaternion.Slerp(launcherModel.rotation, targetRotation, Time.deltaTime * 100f);

        // Lock the rotation on the x and z axis
        launcherModel.rotation = Quaternion.Euler(0f, launcherModel.rotation.eulerAngles.y, 0f);

    }
}
