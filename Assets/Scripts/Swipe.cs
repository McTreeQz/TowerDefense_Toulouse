using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public GameObject menu;
    public GameObject Lyrics;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;
            if(endTouchPos.x < startTouchPos.x)
            {
                Credits();
            }
            if (endTouchPos.x > startTouchPos.x)
            {
                Menu();
            }

        }
    }
    void Credits()
    {

    }
    void Menu()
    {

    }
}
