using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IANavSoldier : MonoBehaviour{

    public Transform movePositionTarget;
    

    public int vie = 3;

    private void Awake()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = movePositionTarget.position;
    }
    private void Update()
    {
        

        if (vie <= 0)
        {
            Destroy(gameObject);
        }
    }
}
