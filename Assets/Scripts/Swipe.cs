using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Swipe
/// 
///      
/// 
/// </summary>


//Permet de changer de page en swipant droite et gauche, il peut être utilisé partout dans le menu.
//
//
//
//

public class Swipe : MonoBehaviour
{
    public GameObject[] pages;

    public AudioClip pageQuiTourne;
    private AudioSource audioSource;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(index);
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;
            if(endTouchPos.x < startTouchPos.x)
            {
                if (index == pages.Length-1)
                {
                    return;
                }
                changePagePlus();
            }
            if (endTouchPos.x > startTouchPos.x)
            {
                if (index == 0)
                {
                    return;
                }
                changePageLess();
            }

        }
    }
    void changePagePlus()
    {
        

        pages[index].SetActive(false);
        index++;
        audioSource.PlayOneShot(pageQuiTourne);
        pages[index].SetActive(true);
        
        

    }
    void changePageLess()
    {
        

        pages[index].SetActive(false);
        index--;
        audioSource.PlayOneShot(pageQuiTourne);
        pages[index].SetActive(true);
        

    }
}
