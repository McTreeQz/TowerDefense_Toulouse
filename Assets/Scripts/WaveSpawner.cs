using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform enemyPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float timeBetweenWaves = 5f;

    private float countdown = 2f;

    [SerializeField]
    private Text waveCountDown;

    private int waveNumber = 0;

    // Update is called once per frame
    void Update()
    {
        if (countdown<= 0f)
        {
            StartCoroutine(spawnWave());

            countdown = timeBetweenWaves;
            
        }

        countdown -= Time.deltaTime;
        waveCountDown.text = Mathf.Floor(countdown).ToString();
    }
    IEnumerator spawnWave()
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
