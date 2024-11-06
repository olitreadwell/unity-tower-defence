using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public BaseTower activeTower;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartTowerPlacement(BaseTower towerToPlace)
    {
        activeTower = towerToPlace;

        // Debug.Log("Tower Placement Started");
    }
}
