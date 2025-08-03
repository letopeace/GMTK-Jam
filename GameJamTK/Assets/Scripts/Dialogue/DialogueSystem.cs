using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;
    
    public PlayerController player;
    public CharacterControl bunny;
    public Transform[] Characters;
    public DialoguePanel[] DialoguePanels;
    public End end;
    
    public Dictionary<CharacterType, Transform> characters;
    public Dictionary<CharacterType, DialoguePanel> dialoguePanels;
    
    public Dialogue[] roomDialogues;
    public Dialogue[] buildingDialogues;
    public Dialogue[] schoolDialogues;

    public CharacterType currentCharacter = CharacterType.Wolf;
    private CharacterType previousCharacter = default;
    

    public bool onWindow = false;
    public bool onButton = false;
    public int ind = 0;
    public bool isSpoken = false;
    public static event Action Spook;

    private SoundLogic sound;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return; 
        }
        instance = this;
        
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

    private void Start()
    {
        sound = GetComponent<SoundLogic>();
    }

    void Update()
    {
        StartDialogue();
    }


    private void StartDialogue()
    {
        if (currentCharacter == CharacterType.Wolf || onButton || isSpoken)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }
    }

    public void Use()
    {
        Dialogue dialogue;
        switch (GameManager.instance.scene)
        {
            case SceneType.Room:
                dialogue = roomDialogues[GameManager.instance.progress[SceneType.Room]];
                break;

            case SceneType.Building:
                dialogue = buildingDialogues[GameManager.instance.progress[SceneType.Building]];
                break;

            default:
                dialogue = schoolDialogues[GameManager.instance.progress[SceneType.School]];
                break;
        }
        DialogueLine(dialogue);
        ind++;
    }

    private void DialogueLine(Dialogue dialogue)
    {
        sound.Play();
        
        dialoguePanels[previousCharacter].gameObject.SetActive(false);
        onWindow = false;

        if (dialogue.GetDialogue(currentCharacter) == null || dialogue.GetDialogue(currentCharacter).dialogue.Length <= ind)
        {
            if (currentCharacter == CharacterType.Lucifer)
            {
                isSpoken = true;
                Spooked();
            }

            if (currentCharacter == CharacterType.Rabbit)
            {
                if (GameManager.instance.progress[SceneType.Building] == 22)
                {
                    end.EndGame();
                }
                else
                {
                    bunny.Jump();
                }
            }
            
            ind = -1;
            return;
        }

        DialogueLine dialogueLine = dialogue.GetDialogue(currentCharacter).dialogue[ind];
        CharacterType character = dialogueLine.character;
        dialoguePanels[character].gameObject.SetActive(true);
        dialoguePanels[character].transform.position = characters[character].position;
        dialoguePanels[character].Message(dialogueLine.message);
        
        if(dialogueLine.choices.Length > 0)
            dialoguePanels[character].Buttons(dialogueLine.choices);
        
        previousCharacter = character;
        onWindow = true;
        player.rb2d.velocity = Vector2.zero;
    }

    public void Spooked()
    {
        Spook?.Invoke();
    }
}
