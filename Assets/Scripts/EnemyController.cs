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
        if(hasReachedEnd == false)
        {
            MoveEnemy();
            CheckDistanceToPathPoint();
        } else
        {
            transform.LookAt(castle.attackPoints[targetAttackPointIndex].position);

            transform.position = Vector3.MoveTowards(transform.position, castle.attackPoints[targetAttackPointIndex].position, enemyMoveSpeed * Time.deltaTime);
            
            HandleAttack();
        }
    }

    void MoveEnemy()
    {

        // Rotate the enemy towards the target
        transform.LookAt(path.points[currentPointIndex].position);

        //  Move the enemy towards the target
        transform.position = Vector3.MoveTowards(transform.position, path.points[currentPointIndex].position, enemyMoveSpeed * Time.deltaTime);
    }

    void CheckDistanceToPathPoint()
    {
        if (Vector3.Distance(transform.position, path.points[currentPointIndex].position) < 0.1f)
        {
            if (currentPointIndex < path.points.Length - 1)
            {
                currentPointIndex++;
            }
            else
            {
                hasReachedEnd = true;

                targetAttackPointIndex = Random.Range(0, castle.attackPoints.Length);
            }
        }
    }

    public void Setup(Castle newCastle, Path newPath)
    {
        castle = newCastle;
        path = newPath;
    }

    private void HandleAttack()
    {
        // before attacking look at the castle
        transform.LookAt(castle.transform);
        
        attackTimer -= Time.deltaTime;

        if(attackTimer <= 0)
        {
            castle.TakeDamage(damagePerAttack);
            attackTimer = timeBetweenAttacks;
        }
    }
}
