using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static Settings instance;
    
    public Slider musicSlider;
    public Slider soundSlider;

    public string musicName = "Music";
    public string soundName = "Sound";

    private void Awake()
    {
        if (instance != null && instance != this)
        {   
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(SetMusic);
        soundSlider.onValueChanged.AddListener(SetSound);
    }

    public void SetMusic(float value)
    {
        PlayerPrefs.SetFloat(musicName, value);
    }

    public void SetSound(float value)
    {
        PlayerPrefs.SetFloat(soundName, value);
    }
    
}
