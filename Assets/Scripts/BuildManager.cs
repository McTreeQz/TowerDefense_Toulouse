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

    private GameObject tower;
    private TowerCosts TourToBuild;
   
    public Vector3 initBuild;
    
    
    public bool canBuild { get { return TourToBuild != null; } }

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void buildTowerOn(node node)
    {
        
        initBuild = node.transform.position;
        initBuild = new Vector3(initBuild.x, initBuild.y-5, initBuild.z);

        if (PlayerStats.money >= TourToBuild.cost)
        {
            PlayerStats.money -= TourToBuild.cost;
            tower = Instantiate(TourToBuild.prefab, initBuild, Quaternion.identity);
            audiosource.PlayOneShot(soundBuild);

            GameObject effectIns = (GameObject)Instantiate(ConstructionEffect, node.transform.position, node.transform.rotation);
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
