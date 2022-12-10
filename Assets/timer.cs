using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Image Soldier_TimerSpawner;

    public Image craftMan_TimeSpawner;
    

    private float initSoldierTimer = 10;
    private float SoldierTimer;

    private float initiCraftTimer = 3;
    private float carftTimer;

     


    void Awake() 
    {

        initiCraftTimer = GetComponent<AlliesSpawner>().timerCraftsman;

        initSoldierTimer = GetComponent<AlliesSpawner>().timerSoldier;

    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(initSoldierTimer);
        Debug.Log("coucou");
        carftTimer = GetComponent<AlliesSpawner>().timerCraftsman;

        SoldierTimer = GetComponent<AlliesSpawner>().timerSoldier;
        //Debug.Log(health);




        /*if (SoldierTimer == initSoldierTimer)
        {
            Soldier_TimerSpawner.enabled = false;
        }
        else
        {
            Soldier_TimerSpawner.enabled = true;
        }*/


        craftMan_TimeSpawner.fillAmount = carftTimer / initiCraftTimer;
        Soldier_TimerSpawner.fillAmount = SoldierTimer / initSoldierTimer;

        // me permet d'avoir un chiffre entre 0 et 1 peut importe le chiffre de base.
    }




}
