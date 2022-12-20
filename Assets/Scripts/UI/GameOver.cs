using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    private int sceneActuel;
    // Start is called before the first frame update
    void Start()
    {
        sceneActuel = SceneManager.GetActiveScene().buildIndex;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.healthPlayer <= 0)
        {
            death();
        }
    }

    public void death()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void restart()
    {
        Time.timeScale = 1f;
        WaveSpawner._enemyAlives = 0;
        SceneManager.LoadScene(sceneActuel);
    }
    
}
