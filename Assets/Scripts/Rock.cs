using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Transform target;

    public GameObject ArrowBleeding;
    public GameObject IANavMesh;

    public float speed = 70f;
    public int degat = 1;

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
        target.GetComponent<IANavSoldier>().health -= degat;




    }
}

