using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueArea : MonoBehaviour
{
    public CharacterType character;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueSystem.instance.currentCharacter = character;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (DialogueSystem.instance.currentCharacter == character)
                DialogueSystem.instance.currentCharacter = CharacterType.Wolf;
        }
    }
}

