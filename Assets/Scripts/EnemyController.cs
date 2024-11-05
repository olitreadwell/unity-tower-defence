using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float enemyMoveSpeed = 5f;


    private Path path;
    private int currentPoint;

    private bool reachedEnd = false;

    public float timeBetweenAttacks, damagePerAttack;
    private float attackCounter;

    private Castle castle;

    // Start is called before the first frame update
    void Start()
    {
        path = FindObjectOfType<Path>();

        castle = FindObjectOfType<Castle>();

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
                castle.TakeDamage(damagePerAttack);
                attackCounter = timeBetweenAttacks;
            }

        }
    }

    void MoveEnemy()
    {

        // Rotate the enemy towards the target
        transform.LookAt(path.points[currentPoint].position);

        
        //  Move the enemy towards the target
        transform.position = Vector3.MoveTowards(transform.position, path.points[currentPoint].position, enemyMoveSpeed * Time.deltaTime);
    }

    void CheckDistanceToPathPoint()
    {
        if (Vector3.Distance(transform.position, path.points[currentPoint].position) < 0.1f)
        {
            if (currentPoint < path.points.Length - 1)
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
