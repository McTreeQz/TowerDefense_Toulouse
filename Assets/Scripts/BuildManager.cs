using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a déjà un BuildManager dans la scène !");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject standardTowerPrefab;
    public GameObject arbaleteTowerPrefab;
    public GameObject bricoleTowerPrefab;
    public GameObject ConstructionEffect;

    private TowerCosts TourToBuild;
    
    public bool canBuild { get { return TourToBuild != null; } }

    public void buildTowerOn(node node)
    {
        if (PlayerStats.money >= TourToBuild.cost)
        {
            PlayerStats.money -= TourToBuild.cost;
            GameObject tower = Instantiate(TourToBuild.prefab, node.transform.position, Quaternion.identity);
            GameObject effectIns = (GameObject)Instantiate(ConstructionEffect, node.transform.position, node.transform.rotation);
            Destroy(effectIns, 2f);
            node.turret = tower;
        }
        else
        {
            return;
        }
        
    }
    
    public void SetTourToBuild(TowerCosts turret)
    {
        TourToBuild = turret;
    }
    
}
