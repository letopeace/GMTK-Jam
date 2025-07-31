using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button[] dialogueChoices;
    public Button dialogueChoiceRed;
    
    private SceneType[] scenes1;
    private SceneType[] scenes2;
    private SceneType[] scenes3;

    public void Message(string message)
    {
        dialogueText.text = message;
    }

    public void Buttons(DialogueChoice[] choices)
    {
        if (dialogueChoices.Length < 3) return;
        
        dialogueChoices[0].onClick.AddListener(Plus0);
        dialogueChoices[1].onClick.AddListener(Plus1);
        dialogueChoices[2].onClick.AddListener(Plus2);
        dialogueChoiceRed.onClick.AddListener(Plus2);
        
        if (choices.Length > 0)
        {
            scenes1 = choices[0].scene;
            dialogueChoices[0].gameObject.SetActive(true);
            dialogueChoices[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choices[0].message;
        }
        if (choices.Length > 1)
        {
            scenes2 = choices[1].scene;
            dialogueChoices[1].gameObject.SetActive(true);
            dialogueChoices[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choices[1].message;
        }
        if (choices.Length > 2)
        {
            if (choices[2].isRed)
            {
                scenes3 = choices[2].scene;
                dialogueChoiceRed.gameObject.SetActive(true);
                dialogueChoiceRed.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choices[2].message;
            }
            else
            {
                scenes3 = choices[2].scene;
                dialogueChoices[2].gameObject.SetActive(true);
                dialogueChoices[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choices[2].message;
            }
        }
    }

    public void Plus0()
    {
        foreach (var scene in scenes1)
        {
            GameManager.instance.progress[scene] += 1;
        }
        dialogueChoices[0].gameObject.SetActive(false);
        dialogueChoices[1].gameObject.SetActive(false);
        dialogueChoices[2].gameObject.SetActive(false);
        
        DialogueSystem.instance.Use();
    }
    public void Plus1()
    {
        foreach (var scene in scenes2)
        {
            GameManager.instance.progress[scene] += 1;
        }
        dialogueChoices[0].gameObject.SetActive(false);
        dialogueChoices[1].gameObject.SetActive(false);
        dialogueChoices[2].gameObject.SetActive(false);
        
        DialogueSystem.instance.Use();
    }
    public void Plus2()
    {
        foreach (var scene in scenes3)
        {
            GameManager.instance.progress[scene] += 1;
        }
        dialogueChoices[0].gameObject.SetActive(false);
        dialogueChoices[1].gameObject.SetActive(false);
        dialogueChoices[2].gameObject.SetActive(false);
        
        DialogueSystem.instance.Use();
    }
    
}
