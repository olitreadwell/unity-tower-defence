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

    public LayerMask groundLayer;

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

            if (Input.GetMouseButtonDown(0))
            {
                isPlacingTower = false;
                Instantiate(activeTower, location, activeTower.transform.rotation);

                indicator.gameObject.SetActive(false);
            }
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

        // Debug.DrawRay(ray.origin, ray.direction * 200f, Color.red);


        RaycastHit hit;

        // If the ray hits the ground layer, set the location to the hit point
        if (Physics.Raycast(ray, out hit, 200f, groundLayer))
        {
            // Set the location to the hit point
            location = hit.point;
        }

        location.y = 0f;
        return location;
    }
}
