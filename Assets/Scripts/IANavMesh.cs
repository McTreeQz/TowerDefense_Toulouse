using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IANavMesh : MonoBehaviour{

    [SerializeField] private Transform movePositionTarget;
    private NavMeshAgent navMeshSoldier;

    private void Awake()
    {
        navMeshSoldier = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        navMeshSoldier.destination = movePositionTarget.position;
    }
}
