using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PAuseMenu : MonoBehaviour
{
    private bool isActive = false;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
