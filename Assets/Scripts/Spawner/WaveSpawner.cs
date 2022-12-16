using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    public GameObject intro;
    public GameObject outro;
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
    public bool End = false;
    

    // Update is called once per frame
    void Update()
    {
        
        begin = intro.GetComponent<IntroManager>().isActive;
        //Debug.Log(_enemyAlives);
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

            if (waveNumber >= waves.Length && _enemyAlives == 0)
            {
                
                StopCoroutine(spawnWave());
                outro.SetActive(true);


            }

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

       
    }
    

    void SpawnEnemy(GameObject enemy)
    {
        
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        _enemyAlives++;
    }
}
