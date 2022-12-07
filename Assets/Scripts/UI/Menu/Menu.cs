using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject battleMenu;

    

    private void Start()
    {
        battleMenu.SetActive(false);

        
    }
    public void StartMenu()
    {
        SceneManager.LoadScene(2);

    }
    public void BackMenu()
    {
        battleMenu.SetActive(false);

    }
    public void BattleMenu()
    {
        battleMenu.SetActive(true);

    }
    public void battle721()
    {
        SceneManager.LoadScene(4);
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