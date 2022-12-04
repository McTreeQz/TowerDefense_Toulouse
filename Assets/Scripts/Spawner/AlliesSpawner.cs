using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform SoldierPrefab;
    [SerializeField]
    private Transform CraftsmanPrefab;
    [SerializeField]
    private Transform spawnPointSoldier;
    [SerializeField]
    private Transform spawnPointCraftsman;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "SpawnSoldier")
                {
                    //Debug.Log("Soldat !");
                    SpawnSoldier();
                }
                if (hit.collider.tag == "SpawnCraftsMan")
                {
                    //Debug.Log("CraftsMan !");
                    SpawnCraftsMan();
                }
            }


            
        }
    }
    void SpawnSoldier()
    {
        Instantiate(SoldierPrefab, spawnPointSoldier.position, spawnPointSoldier.rotation);
    }
    void SpawnCraftsMan()
    {
        Instantiate(CraftsmanPrefab, spawnPointCraftsman.position, spawnPointCraftsman.rotation);
    }
}
