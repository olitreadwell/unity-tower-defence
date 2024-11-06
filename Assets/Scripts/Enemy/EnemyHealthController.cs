using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float totalHealth = 100;
    // Start is called before the first frame update

    public int enemyBounty = 50;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        totalHealth -= damage;
        if (totalHealth <= 0)
        {
            Destroy(gameObject);

            // Add money to the player's total
            MoneyManager.instance.AddMoney(enemyBounty);
        }
    }
}
