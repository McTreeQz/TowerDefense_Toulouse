using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prepareYDef : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
