using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{

    public float enemyMoveSpeed;


    private Path thePath;
    private int currentPoint;

    private bool reachedEnd = false;

    public float timeBetweenAttacks, damagePerAttack;
    private float attackCounter;

    private Castle theCastle;

    // Start is called before the first frame update
    void Start()
    {
        thePath = FindObjectOfType<Path>();

        theCastle = FindObjectOfType<Castle>();

        attackCounter = timeBetweenAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        if(reachedEnd == false)
        {
            MoveEnemy();
            CheckDistanceToPathPoint();
        } else
        {
            attackCounter -= Time.deltaTime;

            if(attackCounter <= 0)
            {
                theCastle.TakeDamage(damagePerAttack);
                attackCounter = timeBetweenAttacks;
            }

        }
    }

    void MoveEnemy()
    {

        // Rotate the enemy towards the target
        transform.LookAt(thePath.points[currentPoint].position);

        
        //  Move the enemy towards the target
        transform.position = Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, enemyMoveSpeed * Time.deltaTime);
    }

    void CheckDistanceToPathPoint()
    {
        if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < 0.1f)
        {
            if (currentPoint < thePath.points.Length - 1)
            {
                currentPoint++;
            }
            else
            {
                reachedEnd = true;
            }
        }
    }
}
