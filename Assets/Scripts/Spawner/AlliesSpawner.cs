
using UnityEngine;
using UnityEngine.UI;

public class AlliesSpawner : MonoBehaviour
{
    public GameObject soldier;
    public GameObject craftsman;

    [Space]
    [Header("Spawner")]
    [SerializeField]
    private Transform spawnPointSoldier;
    [SerializeField]
    private Transform spawnPointCraftsman;

    [Space]
    [Header("Timer")]
    public float timerCraftsman = 15;
    public float initTimerCraftMan;
    public Button craftmanspawner;

    public float timerSoldier = 3;
    public float initTimerSoldier;
    public Button soldierspawner;


    private bool craftmanisActive = false;
    private bool soldierisActive = false;
    


    private void Start()
    {

        initTimerSoldier = timerSoldier;

        initTimerCraftMan = timerCraftsman;



    }
    // Update is called once per frame
    void Update()

    {
        
            if (craftmanisActive == true)
            {
                craftmanspawner.interactable = false;
                timerCraftsman -= Time.deltaTime;
            }
            if (timerCraftsman <= 0)
            {
                craftmanspawner.interactable = true;
                timerCraftsman = initTimerCraftMan;
                craftmanisActive = false;
            }
        
        
            if (soldierisActive == true)
            {
                soldierspawner.interactable = false;
                timerSoldier -= Time.deltaTime;
            }
            if (timerSoldier <= 0)
            {
                soldierspawner.interactable = true;
                timerSoldier = initTimerSoldier;
                soldierisActive = false;
            }
        

        

    }
    public void SpawnSoldier()
    {
        Instantiate(soldier, spawnPointSoldier.position, spawnPointSoldier.rotation);
        soldierisActive = true;
    }
    public void SpawnCraftsMan()
    {
        Instantiate(craftsman, spawnPointSoldier.position, spawnPointSoldier.rotation);
        craftmanisActive = true;
    }
}

