using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public string dialogueId, nextId;
    public DialogueLine[] dialogueLines;
}


[Serializable]
public class DialogueLine
{
	public CharacterType character;
	public int index;
	public string message;
	public DialogueChoice[] choices;

	public bool hasChoices => choices != null && choices.Length > 0;
}

[Serializable]
public class DialogueChoice
{
	public int index;
	public string message;
}

[Serializable]
public enum CharacterType
{
	Lucifer,
	Wolf,
	Rabbit
}