using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundLogic : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] clips;

    private float startVolume;

    private void Start()
    {
        startVolume = audioSource.volume;
        audioSource.volume = startVolume * Settings.instance.soundVolume;
        Settings.soundVolumeChanged += Volume;
    }

    public void Volume()
    {
        audioSource.volume = startVolume * Settings.instance.soundVolume;
    }

    public void Play()
    {
        audioSource.volume = startVolume * Settings.instance.soundVolume;
        
        if (clips == null || clips.Length == 0)
        {
            Debug.LogError("No clips found");
            return; 
        }
        else if (clips.Length == 1)
        {
            audioSource.clip = clips[0];
            audioSource.Play();
        }
        else
        {
            audioSource.clip = clips[Random.Range(0, clips.Length)];
            audioSource.Play();
        }
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void Play(int index)
    {
        audioSource.volume = startVolume * Settings.instance.soundVolume;
        if (clips == null || clips.Length == 0)
        {
            Debug.LogError("No clips found");
            return; 
        }
        audioSource.clip = clips[index];
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Play();
        audioSource.loop = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        audioSource.loop = false;
        audioSource.Stop();
    }
}
