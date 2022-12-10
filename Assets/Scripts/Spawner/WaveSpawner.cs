using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int _enemyAlives = 0;

    private WaveStats  waveStats;
    public WaveStats[] waves;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    float timeBetweenWaves = 5f;
    private float countdown = 2f;

    [SerializeField]
    private Text waveCountDown;

    private int waveNumber = 0;
    //private int enemyNumber = 0;

    // Update is called once per frame
    void Update()
    {
        if (_enemyAlives > 0)
        {
            return;
        }
        if (countdown<= 0f)
        {
            StartCoroutine(spawnWave());

            countdown = timeBetweenWaves;
            return;
            
        }

        countdown -= Time.deltaTime;
        waveCountDown.text = Mathf.Floor(countdown).ToString();
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
