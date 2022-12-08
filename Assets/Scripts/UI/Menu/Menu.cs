using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject battleMenu;
    public GameObject mainMenu;
    public GameObject title;
    public GameObject book;
    
    

    private void Start()
    {
        battleMenu.SetActive(false);
        title.SetActive(true);


    }
    private void Trigger(string trigger)
    {
        if (book != null)
        {
            var animator = book.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger(trigger);
            }
        }
        if (mainMenu != null)
        {
            var animator = mainMenu.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger(trigger);
            }
        }
    }
    public void StartMenu()
    {
        
        Trigger("Open");
        title.SetActive(false);

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
        SceneManager.LoadScene(2);
    }

    public void battle1218()
    {
        Debug.Log("1218");
    }
    public void battle1814()
    {
        Debug.Log("1814");
    }
    private void Update()
    {

        
    }
}