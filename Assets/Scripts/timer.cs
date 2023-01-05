using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// Timer
/// 
///      
/// 
/// </summary>


//L'objectif du script est de montrer visuellement le timer avant de pouvoir réutiliser les alliés.
//
//
//
//

public class timer : MonoBehaviour
{
    public Image Soldier_TimerSpawner;
    public Image craftMan_TimeSpawner;
    public GameObject prefab_artisan;
    public GameObject prefab_soldat;


    private float initSoldierTimer = 10;
    private float SoldierTimer;

    private float initiCraftTimer = 3;
    private float carftTimer;

     


    void Start() 
    {
        // récupère le timer des soldats dans le script IA NAVMESH
        initiCraftTimer = prefab_artisan.GetComponent<AlliesSpawner>().timerCraftsman;
        initSoldierTimer = prefab_soldat.GetComponent<AlliesSpawner>().timerSoldier;

    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(initSoldierTimer);
        Debug.Log("coucou");
        carftTimer = initiCraftTimer ;

        SoldierTimer = prefab_soldat.GetComponent<AlliesSpawner>().timerSoldier;
        //Debug.Log(health);




        if (SoldierTimer == initSoldierTimer)
        {
            Soldier_TimerSpawner.enabled = false;
        }
        else
        {
            Soldier_TimerSpawner.enabled = true;
        }

        // Permet de faire un décompte visuel //
        craftMan_TimeSpawner.fillAmount = carftTimer / initiCraftTimer;
        Soldier_TimerSpawner.fillAmount = SoldierTimer / initSoldierTimer;

       
    }




}
