using UnityEngine;
using UnityEngine.UIElements;

public class Castle : MonoBehaviour
{
    
    [Header("Health")]
    public float totalHealth = 100;
   
    [HideInInspector]
    public float currentHealth;
    private ProgressBar healthProgressBar;

    public Transform[] attackPoints;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;

        var uiDocument = GetComponentInChildren<UIDocument>();
        if (uiDocument == null)
        {
            Debug.Log("UI Document not found");
            return;
        }
        
        if(uiDocument != null)
        {
            Debug.Log("Found UI Document");
            
            var rootVisualElement = uiDocument.rootVisualElement;

            healthProgressBar = rootVisualElement.Q<ProgressBar>("healthProgressBar");

            if (healthProgressBar != null)
            {
                Debug.Log("Found Health Progress Bar");
                UpdateHealthDisplay();
            } else
            {
                Debug.Log("Health Progress Bar not found");
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
        if (healthProgressBar != null)
        {
            healthProgressBar.value = currentHealth;

            var progressElement = healthProgressBar.Q(className: "unity-progress-bar__progress");

            if (progressElement != null)
            {
                Debug.Log("Found Progress Element");
                if (currentHealth <= (totalHealth * 0.3f))
                {
                    progressElement.style.backgroundColor = new StyleColor(Color.red);
                }
                else if (currentHealth > (totalHealth * 0.3f) && currentHealth < (totalHealth * 0.6f))
                {
                    progressElement.style.backgroundColor = new StyleColor(Color.yellow);
                }
                else
                {
                    progressElement.style.backgroundColor = new StyleColor(new Color(0.0f, 0.5f, 0.0f)); // Darker green
                }
            } else
            {
                Debug.Log("Progress Element not found");
            }
        }
    }
}
