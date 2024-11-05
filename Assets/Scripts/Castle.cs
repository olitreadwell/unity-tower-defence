using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public float totalHealth = 100;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageToTake)
    {
        // Reduce the health of the castle
        currentHealth -= damageToTake;

        // Check if the castle has zero health
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            
            // Destroy the castle
            gameObject.SetActive(false);
        }
    }
}
