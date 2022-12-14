using UnityEngine;
using UnityEngine.UI;

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


        craftMan_TimeSpawner.fillAmount = carftTimer / initiCraftTimer;
        Soldier_TimerSpawner.fillAmount = SoldierTimer / initSoldierTimer;

        // me permet d'avoir un chiffre entre 0 et 1 peut importe le chiffre de base.
    }




}
