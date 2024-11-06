using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    public bool levelActive;
    private bool levelVictory;

    private Castle castle;

    public List<EnemyHealthController> enemies = new List<EnemyHealthController>();

    private SimpleEnemySpawner enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        castle = FindObjectOfType<Castle>();
        enemySpawner = FindObjectOfType<SimpleEnemySpawner>();

        levelActive = true;
    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log("Enemies: " + enemies.Count);
        // Debug.Log("Total Enemies left to spawn: " + enemySpawner.totalEnemiesToSpawn);
        if (castle.currentHealth <= 0)
        {
            levelActive = false;
            // levelVictory = false;
            Debug.Log("Castle Destroyed");
        }
        else if (enemies.Count - 1 == 0 && enemySpawner.totalEnemiesToSpawn == 0)
        {
            levelActive = false;
            // levelVictory = true;
            Debug.Log("Level Complete");
        }
    }
}
