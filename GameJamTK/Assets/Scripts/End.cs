using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public Animator endAnim;
    
    public void EndGame()
    {
        endAnim.SetTrigger("end");
        Camera.main.GetComponent<CameraController>().isFree = false;
        DialogueSystem.instance.player.isFree = false;
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
