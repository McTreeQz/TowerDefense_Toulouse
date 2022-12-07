using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arrow : MonoBehaviour
{
    private Transform target;
    

    public GameObject ArrowBleeding;
    public GameObject IANavMesh;

    public float speed  = 70f;
    public float degat  = 1;
    public float slow   = 1;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceInFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceInFrame)
        {
            hit();
            return;
        }

        transform.Translate(dir.normalized * distanceInFrame, Space.World);

    }

    void hit()
    {
        GameObject effectIns = (GameObject)Instantiate(ArrowBleeding, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(gameObject);
        

       
        if (target.tag == "Tower")
        {

            target.GetComponent<Tower>().health -= degat;
            

        }
        else if (target.tag == "Ennemie")
        {

            target.GetComponent<IANavSoldier>().health -= degat;
            if (target.GetComponent<NavMeshAgent>().speed >= 2)
            {

                target.GetComponent<NavMeshAgent>().speed -= slow;
            }

        }
    }
}

