using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour
{
    public GameObject backBarrier;
    public GameObject frontBarrier;
    public DialogueArea rabbitArea;
    
    public float leftCameraBarrier;
    
    public bool justOne = true;

    private void OnEnable()
    {
        DialogueSystem.Spook += UnLockFront;
        backBarrier.GetComponent<Collider2D>().enabled = false;
    }

    private void OnDisable()
    {
        DialogueSystem.Spook -= UnLockFront;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        backBarrier.GetComponent<Collider2D>().enabled = true;
        frontBarrier.GetComponent<Collider2D>().enabled = true;
        DialogueSystem.instance.isSpoken = false;
        justOne = true;
        Camera.main.GetComponent<CameraController>().leftBarrier = leftCameraBarrier + transform.parent.position.x;
        
        DialogueSystem.instance.player.blockLeft = false;
        if (rabbitArea != null)
            rabbitArea.justOne = true;

        if (GetComponent<SceneArea>().type == SceneType.School)
        {
            frontBarrier.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        DialogueSystem.instance.player.blockLeft = true;
        backBarrier.GetComponent<Collider2D>().enabled = false;
    }

    public void UnLockFront()
    {
        if (justOne)
            frontBarrier.GetComponent<Collider2D>().enabled = false;
        
        justOne = false;
    }
}
