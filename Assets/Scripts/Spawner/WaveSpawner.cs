using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    public GameObject intro;
    public GameObject outro;
    public GameObject anecdcote;
    public static int _enemyAlives = 0;

    private WaveStats  waveStats;
    public WaveStats[] waves;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    float timeBetweenWaves = 5f;
    private float countdown = 10f;

    [SerializeField]
    private Text waveCountDown;

    private int waveNumber = 0;
    //private int enemyNumber = 0;

    private bool begin = false;
    public bool End = false;
    

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(begin);
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
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
            waveCountDown.text = Mathf.Floor(countdown).ToString();

            if (waveNumber >= waves.Length && _enemyAlives == 0)
            {
                
                StopCoroutine(spawnWave());
                outro.SetActive(true);


            }
            if (countdown >= 0f)
            {
                if (anecdcote == null)
                {
                    return;
                }
                if (waveNumber == 2)
                {
                    anecdcote.SetActive(true);
                    StartCoroutine(Anecdocte());
                }
            }

        }
        
    }
    IEnumerator spawnWave()
    {
        Debug.Log("coucou");
        WaveStats wave = waves[waveNumber];
        waveNumber++;

        for (int i = 0; i < wave.enemy.Length; i++)
        {
            
            SpawnEnemy(wave.enemy[i]);
            yield return new WaitForSeconds( wave.timerBetweenEnemy);
        }

        waveNumber++;
    }

    IEnumerator Anecdocte()
    {
        yield return new WaitForSeconds(10);
        anecdcote.SetActive(false);
    }
    

    void SpawnEnemy(GameObject enemy)
    {
        
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        _enemyAlives++;
    }

}
