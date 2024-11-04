using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{

    public float enemyMoveSpeed;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowards();
    }

    void MoveTowards()
    {
        // Rotate the enemy towards the target
        transform.LookAt(target);
        
        //  Move the enemy towards the target
        transform.position = Vector3.MoveTowards(transform.position, target.position, enemyMoveSpeed * Time.deltaTime);
    }
}
