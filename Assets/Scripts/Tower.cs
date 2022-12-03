using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshObstacle))]

public class Tower : MonoBehaviour
{
    private Transform target;


    public GameObject   ArrowPrefab;
    public GameObject[] Ennemy;

    public Transform FirePoint;

    public float    range           = 15f;
    public float    fireRate        = 1f;
    public float    fireCountDown   = 0f;
    public int      vie             = 3;



    private void Awake()
    {
        

        


        
        
    }

    private void FixedUpdate()
    {
        Ennemy = GameObject.FindGameObjectsWithTag("Ennemie");
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

        if (Enemy != null && shortestDistance <= range)
        {
            target = Enemy.transform;
        }
       
        if (fireCountDown<= 0 && target != null)
        {
            fire();
            fireCountDown = 1 / fireRate;
        }

        fireCountDown -= Time.deltaTime;
        if (vie <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    void fire()
    {
        GameObject SpawnArrow = (GameObject)Instantiate(ArrowPrefab, FirePoint.position, FirePoint.rotation);
        Arrow arrow = SpawnArrow.GetComponent<Arrow>();

        if(arrow != null)
        {
            arrow.Seek(target.transform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range); //fait apparaître le gizmo de "range"
    }
}