using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Menu : MonoBehaviour
{
    VideoPlayer videoPlayer;
    
    public GameObject battleMenu;
    public GameObject mainMenu;
    public GameObject title;
    public GameObject book;
    public GameObject fondu;
    public GameObject fondLivre;
    public GameObject fondLivreBataille;
    public GameObject videoIntro;
    public GameObject lunchGame;


    private bool videoIsactive = false;
    

    private void Start()
    {
        fondLivreBataille.SetActive(false);
        lunchGame.SetActive(false);
        videoIntro.SetActive(false);
        fondu.SetActive(false);
        battleMenu.SetActive(false);
        title.SetActive(true);

        videoPlayer = GetComponent<VideoPlayer>();

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
        if (fondLivre != null)
        {
            var animator = fondLivre.GetComponent<Animator>();
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
        fondLivre.SetActive(false);
        mainMenu.SetActive(false);
        fondLivreBataille.SetActive(true);
        battleMenu.SetActive(true);

    }
    public void battle721()
    {
        //Trigger("start");
        fondu.SetActive(true);
        videoIntro.SetActive(true);
        videoIsactive = true;


    }

    
    
    public void battle1218()
    {
        Debug.Log("1218");
    }
    public void battle1814()
    {
        Debug.Log("1814");
    }
    public void playGame()
    {
        SceneManager.LoadScene(2);
    }
    private void Update()
    {
        if (videoPlayer.isPlaying == false && videoIsactive == true )
        {
            lunchGame.SetActive(true);
        }
        else
        {
            lunchGame.SetActive(false);
        }
        


    }
    
    
    
    
}