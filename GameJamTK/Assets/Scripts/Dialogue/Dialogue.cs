using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
	public DialogueDictionary[] dialogues;

	public DialogueDictionary GetDialogue(CharacterType characterType)
	{
		for (int i = 0; i < dialogues.Length; i++)
		{
			if (dialogues[i].character == characterType)
				return dialogues[i];
		}
		return null;
	}
}

[Serializable]
public class DialogueDictionary
{
	public CharacterType character;
	public DialogueLine[] dialogue;
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
	public bool isRed = false;
	public int index;
	public string message;
	public SceneType[] scenes;
}

[Serializable]
public enum CharacterType
{
	Lucifer,
	Wolf,
	Rabbit
}

public enum SceneType
{
	Room,
	Building,
	School
}