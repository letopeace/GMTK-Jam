using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolWords : MonoBehaviour
{
    public BoardGame board;
    public Vector3 centerCam;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Camera.main.GetComponent<CameraController>().isFree = false;
        Camera.main.transform.position = centerCam;
        
        DialogueSystem.instance.player.isFree = false;
        board.Launch();
    }
}
