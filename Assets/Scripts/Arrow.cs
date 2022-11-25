using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform target;

    public GameObject ArrowBleeding;

    public float speed = 70f;

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
        Instantiate(ArrowBleeding, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
