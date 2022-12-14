using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AlliesSpawner : MonoBehaviour
{
    public GameObject   soldier;
    public GameObject   craftsman;
    public Image        Soldier_TimerSpawner;
    public Image        craftMan_TimeSpawner;

    [Space]
    [Header("Spawner")]
    [SerializeField]
    private Transform spawnPointSoldier;
    [SerializeField]
    private Transform spawnPointCraftsman;

    [Space]
    [Header("Timer")]
    public float    timerCraftsman = 15;
    public float    initTimerCraftMan;
    public Button   craftmanspawner;
    
    public float    timerSoldier = 3;
    public float    initTimerSoldier;
    public Button   soldierspawner;

    [Space]
    [Header("audio")]
    private AudioSource audioSource;
    public  AudioClip   audio_craftsMan;
    public  AudioClip   audio_soldier;

    private bool    craftmanisActive    = false;
    private bool    soldierisActive     = false;
    private int     sceneActuel;
    


    private void Start()
    {
        sceneActuel = SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();
        Soldier_TimerSpawner.enabled = false;
        craftMan_TimeSpawner.enabled = false;

        initTimerSoldier = timerSoldier;

        initTimerCraftMan = timerCraftsman;



    }
    // Update is called once per frame
    void Update()

    {
        if (sceneActuel >= 4)
        {


            if (craftmanisActive == true)
            {
                craftMan_TimeSpawner.enabled = true;
                craftmanspawner.interactable = false;
                timerCraftsman -= Time.deltaTime;
            }
            if (timerCraftsman <= 0)
            {

                craftmanspawner.interactable = true;
                timerCraftsman = initTimerCraftMan;
                craftmanisActive = false;
                craftMan_TimeSpawner.enabled = false;
            }


            if (soldierisActive == true)
            {
                Soldier_TimerSpawner.enabled = true;
                soldierspawner.interactable = false;
                timerSoldier -= Time.deltaTime;
            }
            if (timerSoldier <= 0)
            {

                soldierspawner.interactable = true;
                timerSoldier = initTimerSoldier;
                soldierisActive = false;
                Soldier_TimerSpawner.enabled = false;
            }

            craftMan_TimeSpawner.fillAmount = timerCraftsman / initTimerCraftMan;
            Soldier_TimerSpawner.fillAmount = timerSoldier / initTimerSoldier;
        }


    }
    public void SpawnSoldier()
    {
        
        audioSource.PlayOneShot(audio_soldier);
        Instantiate(soldier, spawnPointSoldier.position, spawnPointSoldier.rotation);
        soldierisActive = true;
        
    }
    public void SpawnCraftsMan()
    {
        
        audioSource.PlayOneShot(audio_craftsMan);
        Instantiate(craftsman, spawnPointSoldier.position, spawnPointSoldier.rotation);
        craftmanisActive = true;
        
    }
}

