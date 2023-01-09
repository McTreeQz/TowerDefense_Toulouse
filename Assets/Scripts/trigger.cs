using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject intro;
    // Start is called before the first frame update
    void awake()
    {
        
    }

    public void Exit()
    {

        intro.SetActive(true);
        Destroy(gameObject);
    }

}
