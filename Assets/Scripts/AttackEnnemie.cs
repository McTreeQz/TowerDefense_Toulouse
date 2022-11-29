using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackEnnemie : MonoBehaviour
{
    public Transform Target;
    public GameObject Qui;
    private GameObject[] Ennemy;
    public string NameTarget ="";

    private NavMeshAgent Agent;

    public float Range = 5f;
    public int vie = 3;

    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.enabled = true;
        
    }

    // Update is called once per frame
    void FixedUpdate()
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

        if (Enemy != null && shortestDistance <= Range)
        {
            Target = Enemy.transform;

        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
