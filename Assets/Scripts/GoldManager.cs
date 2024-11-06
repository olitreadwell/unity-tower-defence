using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    // Create a public static instance of GoldManager
    public static GoldManager instance;

    private void Awake()
    {
        // Set the instance to this object
        instance = this;
    }

    // Create a public variable to store the player's Gold
    public int currentGold = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Create a method to add Gold to the player's total
    public void AddGold(int amount)
    {
        // Add the amount to the current Gold
        currentGold += amount;
    }

    // Create a method to subtract Gold from the player's total
    public bool SubtractGold(int amount)
    {
        bool canAfford = false;
        if (amount <= currentGold)
        {
            canAfford = true;

            // Debug.Log("Spent " + amount + " Gold. Remaining: " + currentGold);

            currentGold -= amount;
        }


        return canAfford;
    }
}
