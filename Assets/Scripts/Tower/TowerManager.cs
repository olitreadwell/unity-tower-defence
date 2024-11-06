using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;

    private void Awake()
    {
        instance = this;
    }

    public BaseTower activeTower;
    // Start is called before the first frame update

    public Transform indicator;
    public bool isPlacingTower = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlacingTower)
        {
            Vector3 location = GetMouseWorldPosition();
            indicator.position = location;
        }
    }

    public void StartTowerPlacement(BaseTower towerToPlace)
    {
        activeTower = towerToPlace;

        Debug.Log("Tower Placement Started");

        isPlacingTower = true;

        indicator.gameObject.SetActive(true);
    }

    public Vector3 GetMouseWorldPosition()
    {
        // Initialize the location to zero
        Vector3 location = Vector3.zero;

        // Cast a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 200f, Color.red);

        return location;
    }
}
