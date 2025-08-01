using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneArea : MonoBehaviour
{
    public SceneType type;
    public Transform lucifer;
    public Transform luciferPos;
    public Transform rabbit;
    public Transform rabbitPos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.scene = type;

        if (type == SceneType.Building)
        {
            lucifer.position = luciferPos.position;
            rabbit.position = rabbitPos.position;
        }
        else if (type == SceneType.School)
        {
            rabbit.position = rabbitPos.position;
        }
        else
        {
            lucifer.position = luciferPos.position;
        }
    }
}
