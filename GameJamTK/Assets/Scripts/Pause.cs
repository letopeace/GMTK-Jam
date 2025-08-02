using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	public GameObject button;
	public GameObject panel;
	
	public void PauseGame()
	{
		DialogueSystem.instance.player.isFree = false;
		Camera.main.GetComponent<CameraController>().isFree = false;
		button.SetActive(false);
		panel.SetActive(true);
	}

	public void ResumeGame()
	{
		DialogueSystem.instance.player.isFree = true;
		Camera.main.GetComponent<CameraController>().isFree = true;
		button.SetActive(true);
		panel.SetActive(false);
	}
	
	
	
	public void Exit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
	}
}
