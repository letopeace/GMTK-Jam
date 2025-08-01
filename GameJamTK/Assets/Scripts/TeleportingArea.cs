using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingArea : MonoBehaviour
{
    public Vector3 teleportingDirection;

    public SceneType scene;
    public int ind = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.instance.progress[scene] == ind)
            {
                other.transform.position += teleportingDirection;
                Camera.main.transform.position += teleportingDirection;
                Camera.main.GetComponent<CameraController>().leftBarrier = -10f;
            }
        }
    }
}
