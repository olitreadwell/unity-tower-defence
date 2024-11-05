using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{

    [Header("Tower Attributes")]
    public float attackRange = 5f;
    public float attackDamage = 10f;
    public float attackSpeed = 1f;


    [Header("Targeting")]
    public LayerMask targetLayer;
    public Collider[] targetsInRange;
    public List<EnemyController> enemiesInRange = new List<EnemyController>();
    // last time we checked for new targets
    public float lastTargetCheck;
    // time between checking for new targets
    public float targetCheckRate = 0.2f; // 5 times per second not every frame
    public Collider currentTarget;




    // Start is called before the first frame update
    void Start()
    {
        lastTargetCheck = targetCheckRate;
    }

    // Update is called once per frame
    void Update()
    {
        // count down the time until we check for new targets
        lastTargetCheck -= Time.deltaTime;
        if (lastTargetCheck > 0)
        {
            Debug.Log("Not time to check for new targets yet");
            return;
        }

        FindTargets();
        FindEnemiesInRange();
    }

    private void FindTargets() {
        targetsInRange = Physics.OverlapSphere(transform.position, attackRange, targetLayer);       
    }

    private void FindEnemiesInRange() {
        enemiesInRange.Clear();
        foreach (Collider target in targetsInRange)
        {
            var enemy = target.GetComponent<EnemyController>();
            if (enemy == null)
            {
                Debug.LogError("EnemyController not found on target");
                return;
            }
            // if (enemy != null)
            // {
                enemiesInRange.Add(enemy);
            // }
        }
    }
}
