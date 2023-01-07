using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;

/// <summary>
/// 
/// IA des soldats sur le terrains.
/// 
///     - Take Damage
///     - Health system
///     - Couroutines
///     - FONCTIONS DE DEBUG  
/// 
/// </summary>



public enum UnitType { Enemy, Ally }

//L'objectif de ce script est de donner aux ennemis et aux alliés la capacité d'utiliser un navmesh afin de s'orienter dans l'espace
//
//
//Le code est modulaire et permet d'être utilisé pour les ennemis mais aussi les alliés
//J'ai des soucis avec les IA archer ennemis. Je dois leur affilié le code 'tower'

public class IANavSoldier : MonoBehaviour{

    [Space]
    [Header("References")]
    public Transform        movePositionTarget;
    public Image            healthbar;
    public Canvas           Canvas_healthbar;
    public GameObject       arrow;
    public GameObject       money;
    private MeshRenderer    meshRenderer;

    public string NameTarget = "";      // Nom du tag pour récupérer la cible


    private Transform        target;
    private Transform        initHealth;
    private AudioSource      audioSource;
    private GameObject[]     Ennemy;
    private NavMeshAgent     agent;

    private bool enemyDeathPlaying  = false;
    private bool fightPlaying       = false;


    public  float           health;

    [Space]
    [Header("Parameters")]
    public float Range          = 5f;             
    public float InitHealth     = 3f;
    public float care           = 1f;
    public int   degat          = 1;

    public float fireRate = 1f;
    public float fireCountDown  = 0f;

    [Space]
    public int   GoldReward     = 25;

    [Space]
    [Header("Bruitage")]
    public AudioClip Combat         =null;
    public AudioClip EnnemyDeath    =null;
    public AudioClip AlliesDeath    =null;
    public AudioClip GainMoney      =null;



    [SerializeField]
    public UnitType unitType = UnitType.Enemy;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = movePositionTarget.position;
        health = InitHealth;

        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        
    }
    

    private void Update()
    {
        
        if (health == InitHealth)
        {
            Canvas_healthbar.enabled = false;
        }
        else
        {
            Canvas_healthbar.enabled = true;
        }

        //Debug.Log(health / InitHealth);
        Ennemy = GameObject.FindGameObjectsWithTag(NameTarget);
        float shortestDistance = Mathf.Infinity;
        GameObject Enemy = null;

        foreach (GameObject ennemie in Ennemy)
        {
            float distanceToEnnemie = Vector3.Distance(transform.position, ennemie.transform.position);
            if (distanceToEnnemie < shortestDistance)
            {
                shortestDistance = distanceToEnnemie;
                Enemy = ennemie;
            }

        }

        //--------------------------------------------------------------------//
        //                          Take Damage                               //
        //--------------------------------------------------------------------//

        if (Enemy != null && shortestDistance <= Range)
        {
            
            target = Enemy.transform;
            agent.destination = target.position;

            if (target.tag == "Allies" || target.tag == "Ennemie")
            {
                if (fireCountDown <= 0 && target != null)
                {
                    target.GetComponent<IANavSoldier>().health -= degat;
                    
                    fireCountDown = 1 / fireRate;
                    if(gameObject.CompareTag ("Allies") && fightPlaying == false)
                    {
                        fightPlaying = true;
                        StartCoroutine(fight());
                        if (audioSource.isPlaying == false)
                        {
                            fightPlaying = false;
                        }
                    }
                }
                
            }
            else if (target.tag == "Tower" && gameObject.CompareTag("Ennemie")) // Code pour un bélier pas encore implanté
            {
                if (fireCountDown <= 0 && target != null)
                {
                    //Debug.Log("hit");
                    //Debug.Log(target.parent);
                    target.GetComponent<Tower>().health -= degat;
                    fireCountDown = 1 / fireRate;
                }

            }
            else if (target.tag == "Tower" && gameObject.CompareTag("Allies")) // soigneur
            {
                if (fireCountDown <= 0 && target != null && target.GetComponent<Tower>().health <= target.GetComponent<HealthBarTower>().InitHealth)
                {
                    //Debug.Log("hit");
                    //Debug.Log(target.parent);
                    target.GetComponent<Tower>().health += care;
                    fireCountDown = 1 / fireRate;
                    
                }
                else if (target.GetComponent<Tower>().health >= target.GetComponent<HealthBarTower>().InitHealth)
                {
                    agent.destination = movePositionTarget.position;
                    return;
                }

            }
            

        }
        
        else
        {
            agent.destination = movePositionTarget.position;
        }
        fireCountDown -= Time.deltaTime;

        //--------------------------------------------------------------------//
        //                          Health system                             //
        //--------------------------------------------------------------------//

        healthbar.fillAmount = health / InitHealth;

      

        if (health <= 0 && gameObject.CompareTag("Ennemie") && enemyDeathPlaying == false) 
        {

            enemyDeathPlaying = true;
            PlayerStats.money += GoldReward;
            StartCoroutine(death());
            WaveSpawner._enemyAlives--;
            
        }

        else if(health <= 0 && gameObject.CompareTag("Allies"))
        {
            Destroy(gameObject);

        }
    }
    
    // */*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/
    // //               Couroutines                //
    // */*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/

    IEnumerator death()
    {
        meshRenderer.enabled = false;
        money.SetActive(true);
        //agent.destination = agent.transform.position;
        audioSource.PlayOneShot(EnnemyDeath);
        yield return new WaitForSeconds(0.3f);
        audioSource.PlayOneShot(GainMoney);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    IEnumerator fight()
    {
        //agent.destination = agent.transform.position;
        audioSource.PlayOneShot(Combat);
        yield return new WaitForSeconds(4.8f);
        
    }


    // */*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/
    // //            FONCTIONS DE DEBUG            //
    // */*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }




    public void ArrivedAtWall()
    {
        switch (unitType)
        {
            case UnitType.Enemy:

                HurtPlayer();


                break;

            case UnitType.Ally:


                DoSommersault();


                break;

            default:
                break;
        }

    }


    private void DoSommersault()
    {
        //jsrl

    }


    public void HurtPlayer()
    {
        // perte de vie du joueur 
        
            PlayerStats.healthPlayer--;
            WaveSpawner._enemyAlives--;
            Destroy(gameObject);

        
    }

}
