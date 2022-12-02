using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// 
/// IA de l(ennemi blabla utiliser comme ça...
/// 
/// 
/// 
/// </summary>


//L'objectif de ce script est de donner aux ennemis et aux alliés la capacité d'utiliser un navmesh afin de s'orienter dans l'espace
//
//
//Pour l'instant le code fonctionne de cette facon...
//Peut être que je devrais faire CA plutot comme CA mais pour l'instant voila...

public class IANavSoldier : MonoBehaviour{

    [Space]
    [Header("References")]
    public Transform movePositionTarget;
    
    
    public string NameTarget = "";      // Nom du tag pour récupérer blabla

    private Transform target;
    private GameObject[] Ennemy;


    
    private NavMeshAgent agent;

    [Space]
    [Header("Parameters")]
    public float Range = 5f;             //Range expruimée en machin, il faudra p-e changer plus tard...
    public int   vie   = 3;
    public int   degat = 1;

    public float fireRate = 1f;
    public float fireCountDown = 0f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = movePositionTarget.position;
        
        

    }

    private void Update()
    {
        

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
        //                       Condition de machin                          //
        //--------------------------------------------------------------------//

        if (Enemy != null && shortestDistance <= Range)
        {
            Debug.Log("hara");
            target = Enemy.transform;
            agent.destination = target.position;

            if (target.tag == "Allies" || target.tag == "Ennemie")
            {
                if (fireCountDown <= 0 && target != null)
                {
                    target.GetComponent<IANavSoldier>().vie -= degat;
                    fireCountDown = 1 / fireRate;
                }
            }
            else if (target.tag == "Tower")
            {
                Debug.Log("hit");
                Debug.Log(target.parent);
                target.GetComponent<Tower>().vie -= degat;

            }
            

        }
        
        else
        {
            agent.destination = movePositionTarget.position;
        }
        fireCountDown -= Time.deltaTime;
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        

        

        if (vie <= 0)
        {
            Destroy(gameObject);
        }
    }
    void hit()
    {
        target.GetComponent<Tower>().vie -= degat;
    }

    // */*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/
    // //            FONCTIONS DE DEBUG            //
    // */*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
