using UnityEngine;
using UnityEngine.UI;

public class textMoney : MonoBehaviour
{
    public Text moneytext;
    



    // Update is called once per frame
    void Update()
    {
        moneytext.text = PlayerStats.money.ToString();
        
    }
}
