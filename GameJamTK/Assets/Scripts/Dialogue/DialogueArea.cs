using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueArea : MonoBehaviour
{
    public CharacterType character;
    
    public bool justOne = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueSystem.instance.currentCharacter = character;

            if (character == CharacterType.Rabbit && justOne)
            {
                DialogueSystem.instance.Use();
                justOne = false;
            }
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

