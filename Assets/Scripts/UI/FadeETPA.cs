using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeETPA : MonoBehaviour
{
    public float transitionTime = 10f;

    public AudioSource audioSource;

    private void Awake()
    {
        audioSource.volume = 0.3f;
    }
    void Update()
    {
        StartCoroutine(videoComplete());

        if (audioSource.volume <= 0)
        {
            StartCoroutine(EaseIn());
        }
        if (audioSource.volume >= 0.3)
        {
            StopCoroutine(EaseIn());
            audioSource.volume = 0.3f;
            return;
        }


    }

    IEnumerator videoComplete()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(1);
    }
    IEnumerator EaseIn()
    {
        if (audioSource.volume < 0.3)
        {
            yield return new WaitForSeconds(1);
            audioSource.volume += 0.1f;
        }
        
        
    }
}



/*public Animator transition;

    public float transitionTime = 10f;
    private int levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fadeToLevel(1);


    }
    void fadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        StartCoroutine(OnFadeComplete());
       
    }
    
    IEnumerator OnFadeComplete()
    {
        transition.Play("ETPA");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelToLoad);
    }*/
