using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameObject dialogueManager;
    public static int _enemyAlives = 0;

    private WaveStats  waveStats;
    public WaveStats[] waves;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    float timeBetweenWaves = 5f;
    private float countdown = 5f;

    [SerializeField]
    private Text waveCountDown;

    private int waveNumber = 0;
    //private int enemyNumber = 0;


    private bool begin = false;
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        begin = dialogueManager.GetComponent<dialogueManager>().isActive;
        Debug.Log(begin);
        if (begin == true)
        {
            if (_enemyAlives > 0)
            {
                return;
            }
            if (countdown <= 0f)
            {
                StartCoroutine(spawnWave());

                countdown = timeBetweenWaves;
                return;

            }

            countdown -= Time.deltaTime;
            waveCountDown.text = Mathf.Floor(countdown).ToString();
        }
        
    }
    IEnumerator spawnWave()
    {
        WaveStats wave = waves[waveNumber];

        for (int i = 0; i < wave.enemy.Length; i++)
        {
            
            SpawnEnemy(wave.enemy[i]);
            yield return new WaitForSeconds( wave.timerBetweenEnemy);
        }

        waveNumber++;

        if(waveNumber == waves.Length)
        {
            this.enabled = false;
        }

    }
    

    void SpawnEnemy(GameObject enemy)
    {
        
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        _enemyAlives++;
    }
}
