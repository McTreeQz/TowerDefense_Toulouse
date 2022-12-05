using UnityEngine;
using UnityEngine.UI;

public class textLives : MonoBehaviour
{
    public Text healthText;




    // Update is called once per frame
    void Update()
    {
        healthText.text = PlayerStats.healthPlayer.ToString();

    }
}

