using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesSpawner : MonoBehaviour
{
    [Space]
    [Header("Prefab")]
    [SerializeField]
    private Transform SoldierPrefab;
    [SerializeField]
    private Transform CraftsmanPrefab;

    [Space]
    [Header("Spawner")]
    [SerializeField]
    private Transform spawnPointSoldier;
    [SerializeField]
    private Transform spawnPointCraftsman;

    [Space]
    [Header("cost")]
    public int SoldierCost = 50;
    public int CraftsmanCost = 20;

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
                    if (PlayerStats.money >= SoldierCost)
                    {
                        //Debug.Log("Soldat !");
                        SpawnSoldier();
                        PlayerStats.money -= SoldierCost;
                    }
                    else
                    {
                        Debug.Log("pas assez d'argent");
                        return;
                    }
                    
                }
                if (hit.collider.tag == "SpawnCraftsMan")
                {
                    //Debug.Log("CraftsMan !");
                    
                    if (PlayerStats.money >= CraftsmanCost)
                    {
                        //Debug.Log("Soldat !");
                        SpawnCraftsMan();
                        PlayerStats.money -= CraftsmanCost;
                    }
                    else
                    {
                        Debug.Log("pas assez d'argent");
                        return;
                    }
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
