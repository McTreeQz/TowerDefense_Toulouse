using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// HealthBar des Tower
/// 
/// 
/// 
/// </summary>


//L'objectif de ce script est de gérer la barre de vie des tours.
//Pour le moment le script 'Tower' est aussi sur les archer ennemi qui ont leur barre de vie gérer dans IA NAv Soldier, donc j'évite un conflit en créant un autre script.
//
//
//Peut être que je devrais rename le script 'Tower' en 'projectile' mais faudrait le faire sur toutes les dépendances, bref je dois avancer.

public class HealthBarTower : MonoBehaviour
{
    
    public Image    healthbar;
    public Canvas   Canvas_healthbar;

   

    public  float InitHealth;
    private float health;

    

    void Awake()
    {
        InitHealth = GetComponent<Tower>().health;
        
    }

    // Update is called once per frame
    void Update()
    {

        health = GetComponent<Tower>().health;
        
        //Debug.Log(health);


        if (health == InitHealth)
        {
            Canvas_healthbar.enabled = false;
        }
        else
        {
            Canvas_healthbar.enabled = true;
        }

        

       

        healthbar.fillAmount = health / InitHealth; // me permet d'avoir un chiffre entre 0 et 1 peut importe le chiffre de base.
        
    }
}
