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

    public AudioClip soundBuild = null;
    private AudioSource audiosource;

    public float speed = 1;

    public GameObject tower;
    private TowerCosts TourToBuild;
    public Transform targetTower;
    public Vector3 initBuild;
    
    public bool canBuild { get { return TourToBuild != null; } }

    public void buildTowerOn(node node)
    {
        targetTower = node.transform;
        initBuild = node.transform.position;
        initBuild = new Vector3(initBuild.x, initBuild.y-5, initBuild.z);

        if (PlayerStats.money >= TourToBuild.cost)
        {
            PlayerStats.money -= TourToBuild.cost;
            tower = Instantiate(TourToBuild.prefab, initBuild, Quaternion.identity);
            

            GameObject effectIns = (GameObject)Instantiate(ConstructionEffect, tower.transform.position, tower.transform.rotation);
            Destroy(effectIns, 2f);
            node.turret = tower;
        }
        else
        {
            return;
        }
        
    }
    private void Update()
    {
        
    }

    public void SetTourToBuild(TowerCosts turret)
    {
        TourToBuild = turret;
    }

    
}
