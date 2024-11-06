using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("Movement Settings")]
    public float enemyMoveSpeed = 5f;

    [Header("Target GameObjects")]
    private Path path;
    private Castle castle;
    private int currentPointIndex;
    private bool hasReachedEnd = false;

    [Header("Attack Settings")]
    public float timeBetweenAttacks, damagePerAttack;
    private float attackTimer;

    private int targetAttackPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (path == null) {
            path = FindObjectOfType<Path>();
        }

        if (castle == null) 
        {
            castle = FindObjectOfType<Castle>();
        }

        attackTimer = timeBetweenAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        if(path == null)
        {
            // Debug.LogError("Path assigned to EnemyController");
            return;
        }

        if(castle == null)
        {
            // Debug.LogError("Castle assigned to EnemyController");
            return;
        }

        if(path.points.Length == 0)
        {
            // Debug.LogError("Path has no points assigned");
            return;
        }

        if (LevelManager.instance.levelActive == false)
        {
            // Debug.Log("Level is not active");
            return;
        }

        if (castle.currentHealth <= 0)
        {
            // Debug.Log("Castle is destroyed");
            return;
        }

        if(hasReachedEnd == true)
        {
            MoveToAttackPoint();
            Attack();
        }
        
       
        MoveAlongPath();
        CheckDistanceToPathPoint();
    }



    private void MoveToAttackPoint()
    {
        transform.LookAt(castle.attackPoints[targetAttackPointIndex].position);

        transform.position = Vector3.MoveTowards(transform.position, castle.attackPoints[targetAttackPointIndex].position, enemyMoveSpeed * Time.deltaTime);
    }

    void MoveAlongPath()
    {
        // Rotate the enemy towards the target
        transform.LookAt(path.points[currentPointIndex].position);

        //  Move the enemy towards the target
        transform.position = Vector3.MoveTowards(transform.position, path.points[currentPointIndex].position, enemyMoveSpeed * Time.deltaTime);
    }

    void CheckDistanceToPathPoint()
    {
        var distance = Vector3.Distance(transform.position, path.points[currentPointIndex].position);
        if (distance > 0.1f)
        {
            // Debug.Log("Moving to Path Point Index: " + currentPointIndex);
            return;
        }

        if (currentPointIndex >= path.points.Length - 1)
        {
            // Debug.Log("Reached the end of the path");
            hasReachedEnd = true;

            return;
        }
        
        
        // Move to the next point in the path
        currentPointIndex++;
        
    }

    public void Setup(Castle newCastle, Path newPath)
    {
        // Debug.Log("Setting up enemy");

        // Debug.Log("Assigning castle and path to enemy");
        castle = newCastle;
        path = newPath;
    }

    private void Attack()
    {
        // before attacking look at the castle
        transform.LookAt(castle.transform);
        
        attackTimer -= Time.deltaTime;

        if(attackTimer > 0)
        {
            // Debug.Log("Waiting to attack");
            return;
        }
        
        castle.TakeDamage(damagePerAttack);
        attackTimer = timeBetweenAttacks;
        
    }
}
