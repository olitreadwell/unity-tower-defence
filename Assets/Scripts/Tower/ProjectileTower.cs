using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{

    private BaseTower targetTower;

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float intervalBetweenShots = 1f; // 1 shot per second
    private float shotTimer;

    // Start is called before the first frame update
    void Start()
    {
        GetTower();
    }

    // Update is called once per frame
    void Update()
    {
       // count down the time until we can shoot again
        shotTimer -= Time.deltaTime;
        if (shotTimer > 0)
        {
            Debug.Log("Not time to shoot yet");
            return;
        }

        ShootProjectile();
    }

    private void GetTower()
    {
        targetTower = GetComponent<BaseTower>();
    }

    private void ShootProjectile()
    {
        // Reset the shot timer
        shotTimer = intervalBetweenShots;
        
        // Create a new projectile
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    }
}
