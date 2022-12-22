using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverMenu : MonoBehaviour
{
    float timeToDelete = 3;
    public GameObject fondu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToDelete -= Time.deltaTime;
        if (timeToDelete <= 0)
        {
            fondu.SetActive(false);
        }
    }
}
