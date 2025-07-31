using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public string currentDialogueId;
    public Transform[] Characters;
    public DialoguePanel[] DialoguePanels;
    
    public Dictionary<CharacterType, Transform> characters;
    public Dictionary<CharacterType, DialoguePanel> dialoguePanels;
    
    public Dialogue[] allDialogues;

    private CharacterType previousCharacter = default;

    private bool onWindow = false;
    private int ind = 0;

    private void Awake()
    {
        characters = new Dictionary<CharacterType, Transform>()
        {
            { CharacterType.Lucifer , Characters[0]},
            { CharacterType.Wolf , Characters[1]},
            { CharacterType.Rabbit , Characters[2]}
        };

        dialoguePanels = new Dictionary<CharacterType, DialoguePanel>()
        {
            { CharacterType.Lucifer , DialoguePanels[0]},
            { CharacterType.Wolf , DialoguePanels[1]},
            { CharacterType.Rabbit , DialoguePanels[2]}
        };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onWindow)
        {
            Dialogue dialogue = allDialogues.FirstOrDefault(dialogue => dialogue.dialogueId == currentDialogueId);
            StartDialogue(dialogue);
        }
    }

    private void StartDialogue(Dialogue dialogue)
    {
        DialogueLine(dialogue, ind);
        ind++;
    }

    private void DialogueLine(Dialogue dialogue, int ind)
    {
        dialoguePanels[previousCharacter].gameObject.SetActive(false);
        onWindow = false;

        if (dialogue.dialogueLines.Length <= ind)
        {
            currentDialogueId = dialogue.nextId;
            return;
        }
        
        CharacterType character = dialogue.dialogueLines[ind].character;
        dialoguePanels[character].gameObject.SetActive(true);
        dialoguePanels[character].transform.position = characters[character].position;
        dialoguePanels[character].Message(dialogue.dialogueLines[ind].message);

        previousCharacter = character;
        onWindow = true;
    }
}
