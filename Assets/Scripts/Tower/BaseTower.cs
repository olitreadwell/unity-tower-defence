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
    public Collider currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetsInRange = Physics.OverlapSphere(transform.position, attackRange, targetLayer);
    }
}
