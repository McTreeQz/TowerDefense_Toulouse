using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fonduScene : MonoBehaviour
{
    float timeToDelete = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToDelete -= Time.deltaTime;
        if(timeToDelete <= 0)
        {
            timeToDelete = 1;
            gameObject.SetActive(false);
            
        }
        
    }
    
    
}
