using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshObstacle))]

public class Tower : MonoBehaviour
{
    [HideInInspector]
    public Transform target;

    private bool isplaying = false;
    private Transform towertargetPos;
    private GameObject[] Ennemy;
    private Vector3 test;

    //BuildManager build;


    [Space]
    [Header("Référence")]
    //public  Transform       scorpion;
    public  GameObject      ArrowPrefab;
    public  string          tagTarget;
    public  Transform       FirePoint;

    [Space]
    [Header("Paramêtre")]
    public float    range           = 15f;
    public float    fireRate        = 1f;
    public float    fireCountDown   = 0f;
    public float    health          = 3;
    public float    speedConstruct  = 0.2f;

    [Space]
    [Header("AudioEffect")]
    public AudioClip soundFire  = null;
    public AudioClip soundDeath = null;
    public AudioClip soundBuild = null;
    private AudioSource audiosource;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        towertargetPos = transform;
    }
    private void Start()
    {
        
        test = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
    }

    private void FixedUpdate()
    {
       

        if (test.y > transform.position.y && gameObject.CompareTag("Tower"))
        {
            //audiosource.PlayOneShot(soundBuild);
            Vector3 dir = test - transform.position;

            transform.Translate(dir.normalized * (speedConstruct * Time.deltaTime), Space.World);
        }

        Ennemy = GameObject.FindGameObjectsWithTag(tagTarget);
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

        if (Enemy != null && shortestDistance <= range)
        {
            target = Enemy.transform;
        }
       
        if (fireCountDown<= 0 && target != null)
        {
            fire();
            fireCountDown = 1 / fireRate;
        }

        fireCountDown -= Time.deltaTime;
        if (health <= 0 && isplaying == false)
        {
            isplaying = true;
            

            StartCoroutine(death());
        }
        
    }
    private void Update()
    {
       /* if (target != null )
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookdirection = Quaternion.LookRotation(dir);
            Vector3 rotation = lookdirection.eulerAngles;
            scorpion.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }*/
        
    }

    void fire()
    {
        GameObject SpawnArrow = (GameObject)Instantiate(ArrowPrefab, FirePoint.position, FirePoint.rotation);
        Arrow arrow = SpawnArrow.GetComponent<Arrow>();

        if(arrow != null)
        {
            audiosource.PlayOneShot(soundFire);
            arrow.Seek(target.transform);
        }
    }

    IEnumerator death()
    {
        
        audiosource.PlayOneShot(soundDeath);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range); //fait apparaître le gizmo de "range"
    }
}