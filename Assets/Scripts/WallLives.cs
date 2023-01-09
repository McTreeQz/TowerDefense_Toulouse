using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class WallLives : MonoBehaviour
{
    public float range = 5f;
    private GameObject[] Ennemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ennemy = GameObject.FindGameObjectsWithTag("Ennemie");

        foreach (GameObject ennemie in Ennemy)
        {
            float distanceToEnnemie = Vector3.Distance(transform.position, ennemie.transform.position);

            if (distanceToEnnemie <= range)
            {
                PlayerStats.healthPlayer--;
                WaveSpawner._enemyAlives--;
                Destroy(ennemie);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entrer");
        if(other.TryGetComponent<IANavSoldier>(out IANavSoldier _unit))
        {
            if(_unit.unitType == UnitType.Enemy)
            {
                _unit.HurtPlayer();
            }

        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
