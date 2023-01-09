using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Year721 : MonoBehaviour
{
    public GameObject dialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(fadeIn());
    }

    IEnumerator fadeIn()
    {
        yield return new WaitForSeconds(3f);
        dialogue.SetActive(true);
    }
}
