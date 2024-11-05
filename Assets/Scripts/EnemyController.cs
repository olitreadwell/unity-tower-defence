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

    // Start is called before the first frame update
    void Start()
    {
        thePath = FindObjectOfType<Path>();
    }

    // Update is called once per frame
    void Update()
    {
        if(reachedEnd == false)
        {
            MoveEnemy();
            CheckDistanceToPathPoint();
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
