using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerButton : MonoBehaviour
{
    public BaseTower towerToPlace;

    public UIDocument uiDocument;
    // public TowerManager towerManager;

    private void OnEnable()
    {
        // Get the root of the UI document
        VisualElement root = uiDocument.rootVisualElement;

        // Find the button by its name or class
        Button towerButton = root.Q<Button>("placeTowerButton"); // "towerButton" should match the name in UI Builder

        if (towerButton != null)
        {
            // Register the click event using UI Toolkit's syntax
            towerButton.clicked += () => SelectTower();
        }
        else
        {
            Debug.LogWarning("Button not found in the UI Document.");
        }
    }

    private void SelectTower()
    {
        // Call a method in TowerManager, or any logic you want to trigger
        TowerManager.instance.StartTowerPlacement(towerToPlace);
        Debug.Log("OnTowerButtonClick");
    }
}
