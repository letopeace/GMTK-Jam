using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialoguePanel : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public void Message(string message)
    {
        dialogueText.text = message;
    }
}
