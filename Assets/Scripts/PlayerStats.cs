using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Stats
/// 
///      
/// 
/// </summary>


//L'objectif du script est de g�rer les stats en haut � gauche dans le jeu. Ce script est accessible dans le GameManager
//
//
//
//

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 500;

    public static int healthPlayer;
    public int start_healthPlayer = 20;
    void Start()
    {
        money = startMoney;
        healthPlayer = start_healthPlayer;
    }
    private void Update()
    {
       // Debug.Log(healthPlayer);
    }

    // Update is called once per frame

}
