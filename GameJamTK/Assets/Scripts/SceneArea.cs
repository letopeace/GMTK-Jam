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

    private CharacterControl luci, rabbi;

    private void OnEnable()
    {
        if (lucifer != null)
            luci = lucifer.GetComponent<CharacterControl>();
        
        if (rabbit != null)
            rabbi = rabbit.GetComponent<CharacterControl>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.scene = type;

        if (type == SceneType.Building)
        {
            lucifer.position = luciferPos.position; 
            rabbit.position = rabbitPos.position;
            
            luci.Switch(false);
            rabbi.Switch(true);
        }
        else if (type == SceneType.School)
        {
            /*
            if (GameManager.instance.progress[SceneType.School] != 0)
            {
                rabbit.position = rabbitPos.position;
                rabbi.Switch(false);
            }
            */
        }
        else
        {
            lucifer.position = luciferPos.position;
            luci.Switch(true);
        }
    }
}
