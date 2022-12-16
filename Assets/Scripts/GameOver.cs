using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private int sceneActuel;
    // Start is called before the first frame update
    void Start()
    {
        sceneActuel = SceneManager.GetActiveScene().buildIndex;
        gameObject.SetActive(false);
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
        gameObject.SetActive(true);
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene(2);
    }
    public void restart()
    {
        Time.timeScale = 1f;
        WaveSpawner._enemyAlives = 0;
        SceneManager.LoadScene(sceneActuel);
    }
}
