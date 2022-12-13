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

    
    public GameObject ConstructionEffect;

    public AudioClip soundBuild = null;
    private AudioSource audiosource;

    public float ConstructionSpeed = 1;

    
    private TowerCosts TourToBuild;
   
    
    
    
    public bool canBuild { get { return TourToBuild != null; } }

    public void SetTourToBuild(TowerCosts tower)
    {
        TourToBuild = tower;
    }


    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void buildTowerOn(node node)
    {
        
        

        if (PlayerStats.money >= TourToBuild.cost)
        {
            PlayerStats.money -= TourToBuild.cost;
            GameObject tower = (GameObject)Instantiate(TourToBuild.prefab, node.getBuildPosition(), Quaternion.identity);
            audiosource.PlayOneShot(soundBuild);

            GameObject effectIns = (GameObject)Instantiate(ConstructionEffect, node.transform.position, node.transform.rotation);
            Destroy(effectIns, 2f);
            node.turret = tower;
        }
        
        
    }
    private void Update()
    {
        
    }

    
    
}
