using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectIndexArea : MonoBehaviour
{
    public SceneType scene;
    public int index;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.progress[scene] = index;
        }
    }
}
