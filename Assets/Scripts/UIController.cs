using UnityEngine;
using UnityEngine.UIElements;  // Note: This is for UI Toolkit, not UnityEngine.UI

public class UIController : MonoBehaviour
{
    public UIDocument uiDocument;
    public TowerManager towerManager;

    private void OnEnable()
    {
        // Get the root of the UI document
        VisualElement root = uiDocument.rootVisualElement;

        // Find the button by its name or class
        Button towerButton = root.Q<Button>("placeTowerButton"); // "towerButton" should match the name in UI Builder

        if (towerButton != null)
        {
            // Register the click event using UI Toolkit's syntax
            towerButton.clicked += OnTowerButtonClick;
        }
        else
        {
            Debug.LogWarning("Button not found in the UI Document.");
        }
    }

    private void OnTowerButtonClick()
    {
        // Call a method in TowerManager, or any logic you want to trigger
        // towerManager.YourMethodHere();
        Debug.Log("Tower button clicked!");
    }
}
