using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


/// <summary>
/// 
/// IA des soldats sur le terrains.
/// 
/// 
/// 
/// </summary>


//L'objectif de ce script est de donner aux ennemis et aux alliés la capacité d'utiliser un navmesh afin de s'orienter dans l'espace
//
//
//Le code est modulaire et permet d'être utilisé pour les ennemis mais aussi les alliés
//Peut être que je devrais faire CA plutot comme CA mais pour l'instant voila...

public class IANavSoldier : MonoBehaviour{

    [Space]
    [Header("References")]
    public Transform    movePositionTarget;
    public Image        healthbar;
    public Canvas       Canvas_healthbar;
    public GameObject   arrow;

    public string NameTarget = "";      // Nom du tag pour récupérer la cible

    private Transform       target;
    private Transform       initHealth;

    private GameObject[]    Ennemy;
    private NavMeshAgent    agent;
    public  float           health;

    [Space]
    [Header("Parameters")]
    public float Range          = 5f;             
    public float InitHealth     = 3f;
    public float care           = 1f;
    public int   degat          = 1;

    public float fireRate = 1f;
    public float fireCountDown  = 0f;

    [Space]
    public int   GoldReward     = 25;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = movePositionTarget.position;
        health = InitHealth;


    }
    

    private void Update()
    {
        
        if (health == InitHealth)
        {
            Canvas_healthbar.enabled = false;
        }
        else
        {
            Canvas_healthbar.enabled = true;
        }

        //Debug.Log(health / InitHealth);
        Ennemy = GameObject.FindGameObjectsWithTag(NameTarget);
        float shortestDistance = Mathf.Infinity;
        GameObject Enemy = null;

        foreach (GameObject ennemie in Ennemy)
        {
            float distanceToEnnemie = Vector3.Distance(transform.position, ennemie.transform.position);
            if (distanceToEnnemie < shortestDistance)
            {
                shortestDistance = distanceToEnnemie;
                Enemy = ennemie;
            }

        }

        //--------------------------------------------------------------------//
        //                          Take Damage                               //
        //--------------------------------------------------------------------//

        if (Enemy != null && shortestDistance <= Range)
        {
            
            target = Enemy.transform;
            agent.destination = target.position;

            if (target.tag == "Allies" || target.tag == "Ennemie")
            {
                if (fireCountDown <= 0 && target != null)
                {
                    target.GetComponent<IANavSoldier>().health -= degat;
                    
                    fireCountDown = 1 / fireRate;
                }
                
            }
            else if (target.tag == "Tower" && gameObject.CompareTag("Ennemie"))
            {
                if (fireCountDown <= 0 && target != null)
                {
                    //Debug.Log("hit");
                    //Debug.Log(target.parent);
                    target.GetComponent<Tower>().health -= degat;
                    fireCountDown = 1 / fireRate;
                }

            }
            else if (target.tag == "Tower" && gameObject.CompareTag("Allies"))
            {
                if (fireCountDown <= 0 && target != null && target.GetComponent<Tower>().health < target.GetComponent<HealthBarTower>().InitHealth)
                {
                    //Debug.Log("hit");
                    //Debug.Log(target.parent);
                    target.GetComponent<Tower>().health += care;
                    fireCountDown = 1 / fireRate;
                    return;
                }
                else if (target.GetComponent<Tower>().health >= target.GetComponent<HealthBarTower>().InitHealth)
                {
                    agent.destination = movePositionTarget.position;
                    return;
                }

            }
            

        }
        
        else
        {
            agent.destination = movePositionTarget.position;
        }
        fireCountDown -= Time.deltaTime;

        //--------------------------------------------------------------------//
        //                          Health system                             //
        //--------------------------------------------------------------------//

        healthbar.fillAmount = health / InitHealth;

        if (agent.remainingDistance <= 1)
        {
            if (gameObject.CompareTag("Ennemie"))
            {
                PlayerStats.healthPlayer--;
                WaveSpawner._enemyAlives--;
                Destroy(gameObject);
            }
        }

        if (health <= 0 && gameObject.CompareTag("Ennemie"))
        {
            PlayerStats.money += GoldReward;
            Destroy(gameObject);
            WaveSpawner._enemyAlives--;
        }

        else if (health <= 0 )
        {
            
            Destroy(gameObject);
        }
    }


    // */*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/
    // //            FONCTIONS DE DEBUG            //
    // */*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
