using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    

    

    private void Start()
    {
        
        
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(1);

    }
    public void BattleMenu()
    {
        SceneManager.LoadScene(2);

    }
    public void battle721()
    {
        SceneManager.LoadScene(3);
    }

    public void battle1218()
    {
        Debug.Log("1218");
    }
    public void battle1814()
    {
        Debug.Log("1814");
    }
}