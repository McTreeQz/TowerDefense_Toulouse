using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
