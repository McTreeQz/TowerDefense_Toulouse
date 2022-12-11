using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class dialogueManager : MonoBehaviour
{
    public GameObject dialogue;
    public TextMeshProUGUI textComponent;

    [TextArea(3, 10)]
    public string[] lines;

    public float textSpeed;

    private int index;
    public bool isActive = false;

    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }
    private void Update()
    {
        /*if (textComponent.text == lines[index])
        {
            nextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }*/
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
            yield return new WaitForSeconds(textSpeed*Time.deltaTime);
        }
    }
    public void nextLine()
    {
        Debug.Log("next");
        

      if (index < lines.Length - 1)
      {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

      }
      else
      {
            dialogue.SetActive(false);
            isActive = true;
      }

    }
}
