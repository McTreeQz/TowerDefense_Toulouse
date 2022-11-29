using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IANavSoldier : MonoBehaviour{

    public Transform movePositionTarget;
    
    public string NameTarget = "";

    private Transform Target;
    private GameObject[] Ennemy;
    private NavMeshAgent agent;

    public float Range = 5f;
    public int vie = 3;
    public int degat = 1;

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

        if (Enemy != null && shortestDistance <= Range)
        {
            Target = Enemy.transform;
            agent.destination = Target.position;
            Target.GetComponent<IANavSoldier>().vie -= degat;

        }
        else
        {
            agent.destination = movePositionTarget.position;
        }

        if (vie <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    void hit()
    {
        
    }
}
