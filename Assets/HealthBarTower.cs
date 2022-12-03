using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarTower : MonoBehaviour
{
    public Image healthbar;
    public Canvas Canvas_healthbar;

    private Transform infoHealthTower;

    private float InitHealth;
    private float health;
    // Start is called before the first frame update
    void Awake()
    {
        InitHealth = GetComponent<Tower>().health;

    }

    // Update is called once per frame
    void Update()
    {

        health = GetComponent<Tower>().health;
        
        Debug.Log(health);
        

        if (health == InitHealth)
        {
            Canvas_healthbar.enabled = false;
        }
        else
        {
            Canvas_healthbar.enabled = true;
        }

        healthbar.fillAmount = health / InitHealth;
        
    }
}
