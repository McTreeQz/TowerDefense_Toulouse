using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class rotationScorpion : MonoBehaviour
{
    public Transform scorpion;
    private Transform target;

    //Tower tower;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void FixedUpdate()
    {
        target = gameObject.GetComponent<Tower>().target;
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookdirection = Quaternion.LookRotation(dir);
            Vector3 rotation = lookdirection.eulerAngles;
            scorpion.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }
}
