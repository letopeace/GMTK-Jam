using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingArea : MonoBehaviour
{
    public Vector3 teleportingDirection;

    public SceneType scene;
    public int ind = 0;
    public bool invert = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            bool check = GameManager.instance.progress[scene] == ind;
            check = invert ? !check : check;
            
            if (check)
            {
                other.transform.position += teleportingDirection;
                Camera.main.transform.position += teleportingDirection;
                Camera.main.GetComponent<CameraController>().leftBarrier = -10f;
            }
        }
    }
}
