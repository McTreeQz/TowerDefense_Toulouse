using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class IntroManager : MonoBehaviour
{
    public GameObject GameManager;
    
    
    public GameObject dialogue;
    public TextMeshProUGUI textComponent;

    [TextArea(3, 10)]
    public string[] lines;

    public float textSpeed;

    private int index;
    public bool isActive = false;

    Coroutine LineReadingCoro = null;
    

    private void Start()
    {
        
        
        textComponent.text = string.Empty;
        StartDialogue();
        
    }
    private void Update()
    {
        
        
    }

    void StartDialogue()
    {
        index = 0;
        LineReadingCoro = StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(1/textSpeed);
        }

        LineReadingCoro = null;
    }

    private void FinishSentence()
    {

        textComponent.text = lines[index].ToString();


    }


    public void nextLine()
    {
        //Debug.Log("next");
       
      if(LineReadingCoro != null)
        {
            StopCoroutine(LineReadingCoro);
            LineReadingCoro = null;
            FinishSentence();
            return;
        }

      if (index < lines.Length - 1)
      {
            index++;
            textComponent.text = string.Empty;

            LineReadingCoro = StartCoroutine(TypeLine());

      }
      else
      {
            dialogue.SetActive(false);
            isActive = true;
      }

    }
}
