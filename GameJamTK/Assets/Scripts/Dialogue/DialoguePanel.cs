using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button[] buttons;
    public Button redButton;
    
    private SceneType[] scenes1;  //  Временное хранилище, поскольку мы не можем напрямую передать значение кнопке
    private SceneType[] scenes2;
    private SceneType[] scenes3;

    public void Message(string message)
    {
        dialogueText.text = message;
    }

    public void Buttons(DialogueChoice[] choices)  // Здесь варианты ответов принимается. В вариантах ответов могут содержаться возоможные продвигатели сюжет
    {
        if (buttons.Length != 3) return;

        foreach (Button button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }
        
        buttons[0].onClick.AddListener(Plus0);
        buttons[1].onClick.AddListener(Plus1);
        buttons[2].onClick.AddListener(Plus2);
        redButton.onClick.AddListener(Plus2);
        DialogueSystem.instance.onButton = true;
        
        if (choices.Length >= 1)  
        {
            scenes1 = choices[0].scenes;
            buttons[0].gameObject.SetActive(true);
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choices[0].message;
        }
        if (choices.Length >= 2)
        {
            scenes2 = choices[1].scenes;
            buttons[1].gameObject.SetActive(true);
            buttons[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choices[1].message;
        }
        if (choices.Length >= 3)
        {
            if (choices[2].isRed)
            {
                scenes3 = choices[2].scenes;
                redButton.gameObject.SetActive(true);
                redButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choices[2].message;
            }
            else
            {
                scenes3 = choices[2].scenes;
                buttons[2].gameObject.SetActive(true);
                buttons[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choices[2].message;
            }
        }
    }

    public void Plus0()
    {
        foreach (var scene in scenes1)
        {
            GameManager.instance.progress[scene] += 1;
            Debug.Log($"{scene}: {GameManager.instance.progress[scene]}");
        }
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
        DialogueSystem.instance.onButton = false;
        
        DialogueSystem.instance.Use();
    }
    public void Plus1()
    {
        foreach (var scene in scenes2)
        {
            GameManager.instance.progress[scene] += 1;
            Debug.Log($"{scene}: {GameManager.instance.progress[scene]}");
        }
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
        DialogueSystem.instance.onButton = false;
        
        DialogueSystem.instance.Use();
    }
    public void Plus2()
    {
        foreach (var scene in scenes3)
        {
            GameManager.instance.progress[scene] += 1;
            Debug.Log($"{scene}: {GameManager.instance.progress[scene]}");
        }
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
        DialogueSystem.instance.onButton = false;
        
        DialogueSystem.instance.Use();
    }
    
}
