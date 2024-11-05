using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Castle : MonoBehaviour
{
    public float totalHealth = 100;
    private float currentHealth;
    private Label healthValueLabel;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;

        var uiDocument = GetComponentInChildren<UIDocument>();
        if(uiDocument != null)
        {
            Debug.Log("Found UI Document");
            
            var rootVisualElement = uiDocument.rootVisualElement;

            healthValueLabel = rootVisualElement.Q<Label>("healthValueLabel");

            if (healthValueLabel != null)
            {
                Debug.Log("Found Health Value Label");
                UpdateHealthDisplay();
            } else
            {
                Debug.Log("Health Value Label not found");
            }
        } else
        {
            Debug.Log("UI Document not found");
        }
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

        // Update the health display
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        // Update the health display
        if (healthValueLabel != null)
        {
            healthValueLabel.text = "Health: " + currentHealth.ToString();
        }
    }
}
