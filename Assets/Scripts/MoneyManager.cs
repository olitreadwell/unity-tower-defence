using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    // Create a public static instance of MoneyManager
    public static MoneyManager instance;

    private void Awake()
    {
        // Set the instance to this object
        instance = this;
    }

    // Create a public variable to store the player's money
    public int currentMoney = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Create a method to add money to the player's total
    public void AddMoney(int amount)
    {
        // Add the amount to the current money
        currentMoney += amount;
    }

    // Create a method to subtract money from the player's total
    public bool SubtractMoney(int amount)
    {
        bool canAfford = false;
        if (amount <= currentMoney)
        {
            canAfford = true;

            Debug.Log("Spent " + amount + " money. Remaining: " + currentMoney);

            currentMoney -= amount;
        }

        return canAfford;
    }
}
