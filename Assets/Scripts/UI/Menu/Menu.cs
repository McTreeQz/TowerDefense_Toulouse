using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Menu : MonoBehaviour
{
    VideoPlayer videoPlayer;


    [Space]
    [Header("R�f�rence")]
    public GameObject battleMenu;
    public GameObject mainMenu;
    public GameObject title;
    public GameObject book;
    public GameObject fondLivre;
    public GameObject fondLivreBataille;
    public GameObject videoIntro;
    public GameObject lunchGame;
    public GameObject cameraMenu;
    public GameObject fondu;
    public GameObject option;
    public GameObject codex;
    public GameObject credits;
    public GameObject Battle1218;

    [Space]
    [Header("Audio")]
    public AudioClip pageQuiTourne = null;
    public AudioClip boutonValide = null;
    public AudioClip boutonRetour = null;
    public AudioClip boutonPlay = null;
    public AudioClip cinematique = null;
    public AudioClip BO = null;

    private AudioSource audioSource;
    private float volumeBO = 0f;
    private float maxVolumeBO = 0.09f;
    public AudioSource bandeOriginale;
    private float timeToDelete = 3;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    private bool mainMenuIsActive = false;
    private bool videoIsactive = false;
    

    private void Start()
    {
        Time.timeScale = 1;
        
        audioSource = GetComponent<AudioSource>();
        fondLivreBataille.SetActive(false);
        lunchGame.SetActive(false);
        videoIntro.SetActive(false);
        option.SetActive(false);
        codex.SetActive(false);
        credits.SetActive(false);
        Battle1218.SetActive(false);
        

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
        if (cameraMenu != null)
        {
            var animator = cameraMenu.GetComponent<Animator>();
            if (animator != null)
            {

                animator.SetTrigger(trigger);
            }
        }
    }
    
    public void StartMenu()
    {
        boutonValid();
        Trigger("Open");
        title.SetActive(false);
        mainMenuIsActive = true;

    }
    public void BackMenu()
    {
        boutonBack();
        mainMenuIsActive = true;
        mainMenu.SetActive(true);
        battleMenu.SetActive(false);
        fondLivreBataille.SetActive(false);
        fondLivre.SetActive(true);
        option.SetActive(false);
        codex.SetActive(false);
        credits.SetActive(false);
        Battle1218.SetActive(false);
        Tourne();

    }
    public void BattleMenu()
    {
        mainMenuIsActive = false;
        boutonValid();
        Tourne();
        fondLivre.SetActive(false);
        mainMenu.SetActive(false);
        fondLivreBataille.SetActive(true);
        battleMenu.SetActive(true);

    }
    public void battle721()
    {
        mainMenuIsActive = false;
        //Trigger("start");
        //fondu.SetActive(true);
        maxVolumeBO = 0;
        boutonValid();
        Tourne();
        videoIntro.SetActive(true);
        videoIsactive = true;
        audioSource.PlayOneShot(cinematique);


    }

    
    
    public void battle1218()
    {
        mainMenuIsActive = false;
        battleMenu.SetActive(false);
        boutonValid();
        Tourne();
        fondLivreBataille.SetActive(false);
        fondLivre.SetActive(false);
        mainMenu.SetActive(false);
        Battle1218.SetActive(true);
        
        Debug.Log("1218");
    }
    public void battle1814()
    {
        mainMenuIsActive = false;
        boutonBack();
        Tourne();
        Debug.Log("1814");
    }
    public void Option()
    {
        mainMenuIsActive = false;
        boutonValid();
        Tourne();
        fondLivre.SetActive(false);
        mainMenu.SetActive(false);
        option.SetActive(true);

        Debug.Log("1814");
    }
    public void Codex()
    {
        mainMenuIsActive = false;
        boutonValid();
        Tourne();
        fondLivre.SetActive(false);
        mainMenu.SetActive(false);
        codex.SetActive(true);

        Debug.Log("1814");
    }
    void Credits()
    {
        Tourne();
        fondLivre.SetActive(false);
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }
    public void quit()
    {
        boutonBack();

        Application.Quit();
    }
    public void playGame()
    {
        audioSource.PlayOneShot(boutonValide);
        SceneManager.LoadScene(2);
    }
    private void Update()
    {
        timeToDelete -= Time.deltaTime;
        if (timeToDelete <= 0)
        {
            fondu.SetActive(false);
        }

        if (mainMenuIsActive == true && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if (mainMenuIsActive == true && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;
            if (endTouchPos.x < startTouchPos.x)
            {
                Credits();
            }
            if (endTouchPos.x > startTouchPos.x)
            {
                BackMenu();
            }

        }


        bandeOriginale.volume = volumeBO;

        if (videoPlayer.isPlaying == false && videoIsactive == true )
        {
            lunchGame.SetActive(true);
        }
        else
        {
            lunchGame.SetActive(false);
        }

        if (volumeBO < maxVolumeBO)
        {
            StartCoroutine(fadeIn());
        }
        else
        {
            volumeBO = maxVolumeBO ;
            return;
        }
      
        
        
    }
    void boutonValid()
    {
        audioSource.PlayOneShot(boutonValide);
        audioSource.volume = 0.3f;
    }
    void boutonBack()
    {
        audioSource.PlayOneShot(boutonRetour);
        audioSource.volume = 0.3f;
    }
    void Tourne()
    {
        audioSource.PlayOneShot(pageQuiTourne);
        
        audioSource.volume = 0.3f;
    }


    IEnumerator fadeIn()
    {
        
            yield return new WaitForSeconds(1f);
            volumeBO += 0.01f;
    }
    

}