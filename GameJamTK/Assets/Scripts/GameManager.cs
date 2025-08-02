using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject array;
    
    public SceneType scene = SceneType.Room;
    public Dictionary<SceneType, int> progress;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return; 
        }
        
        progress = new Dictionary<SceneType, int>()
        {
            { SceneType.Room, 0 },
            { SceneType.Building , 0 },
            { SceneType.School , 0 }
        };
    }

}
