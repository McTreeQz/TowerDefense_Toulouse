using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeETPA : MonoBehaviour
{
    public float transitionTime = 10f;

    void Update()
    {
        StartCoroutine(videoComplete());


    }

    IEnumerator videoComplete()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(1);
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
