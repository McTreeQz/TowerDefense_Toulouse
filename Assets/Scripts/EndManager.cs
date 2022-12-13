using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class EndManager : MonoBehaviour
{

    private int sceneActuel;
    public GameObject EndDialogue;
    public GameObject dialogue;
    public TextMeshProUGUI textComponent;

    [TextArea(3, 10)]
    public string[] lines;

    public float textSpeed;

    private int index;
    private void Awake()
    {
        EndDialogue.SetActive(false);
    }


    private void Start()
    {

        sceneActuel = SceneManager.GetActiveScene().buildIndex;
        textComponent.text = string.Empty;
        StartDialogue();
       
    }
    private void Update()
    {

        
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed * Time.deltaTime);
        }
    }
    public void nextLine()
    {
        //Debug.Log("next");


        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }
        else
        {
            dialogue.SetActive(false);
            SceneManager.LoadScene(sceneActuel+=1);
            
        }

    }
}