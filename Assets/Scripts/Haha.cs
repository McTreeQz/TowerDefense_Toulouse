using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshObstacle))]

public class Haha : MonoBehaviour
{
    private NavMeshObstacle Obstacle;
    private MeshRenderer Wall;

    

    public float range = 15f;
    public float vie = 100;

    public GameObject [] Ennemy;

    private void Awake()
    {
        Obstacle = GetComponent<NavMeshObstacle>();
        Obstacle.enabled = true;

        Wall = GetComponent<MeshRenderer>();
        Wall.enabled = true;


        
        
    }

    private void FixedUpdate()
    {
        Ennemy = GameObject.FindGameObjectsWithTag("Ennemie");

        foreach (GameObject ennemie in Ennemy)
        {
            float distanceToEnnemie = Vector3.Distance(transform.position, ennemie.transform.position);

            if (distanceToEnnemie <= range)
            {
                vie -= Time.deltaTime;

                
            }
        }
       
        if (vie <= 0)
        {
            Obstacle.enabled = false;
            Wall.enabled = false;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range); //fait apparaître le gizmo de "range"
    }
}