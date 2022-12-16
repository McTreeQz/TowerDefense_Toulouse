using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// MenuPause
/// 
/// 
/// 
/// </summary>


//L'objectif de ce script est de g�rer le menu Pause.
//
//
//
//

public class PAuseMenu : MonoBehaviour
{
    private bool isActive = false;
    public GameObject pauseMenu;
    private int sceneActuel;

    // Start is called before the first frame update
    void Start()
    {
        sceneActuel = SceneManager.GetActiveScene().buildIndex;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(Time.timeScale);
        if (isActive == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void RestartScene()
    {
        isActive = false;
        SceneManager.LoadScene(sceneActuel);

    }
    public void pauseMenuOn()
    {
        pauseMenu.SetActive(true);
        isActive = true;
    }
    public void pauseMenuOff()
    {
        pauseMenu.SetActive(false);
        isActive = false;
    }
}
