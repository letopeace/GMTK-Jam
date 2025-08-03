using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLogic : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioClip[] clips;
    public int ind = 0;
    public float volume = 1;

    public bool isFirst = true;
    public float speed = 3;


    private void Start()
    {
        Settings.musicVolumeChanged += Volume;
    }

    public void Volume()
    {
        if (isFirst)
        {
            audioSource1.volume = Settings.instance.musicVolume * volume;
        }
        else
        {
            audioSource2.volume = Settings.instance.musicVolume * volume;
        }
    }

    public void Play(int index)
    {
        ind = index;
        StopAllCoroutines();
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        Debug.Log("Music Changed");
        
        float correctVolume = volume * Settings.instance.musicVolume;
        float time = 0;
        float firstGate = speed * 0.66f;
        float secondGate = speed * 0.33f;

        if (isFirst)
        {
            audioSource2.clip = clips[ind];
        }
        else
        {
            audioSource1.clip = clips[ind];
        }

        bool a = false, b = false;
        while (time < speed)
        {
            time += Time.deltaTime;
            if (time < firstGate)
            {
                if (isFirst)
                {
                    audioSource1.volume = Mathf.Clamp01((firstGate - time) / firstGate * correctVolume);
                }
                else
                {
                    audioSource2.volume = Mathf.Clamp01((firstGate - time) / firstGate * correctVolume);
                }
            }
            else if (!a)
            {
                if (isFirst)
                {
                    audioSource1.volume = 0;
                    audioSource1.Stop();
                }
                else
                {
                    audioSource2.volume = 0;
                    audioSource2.Stop();
                }
                a = true;
            }

            if (time > secondGate)
            {
                if (!b)
                {
                    if (isFirst)
                    {
                        audioSource2.Play();
                    }
                    else
                    {
                        audioSource1.Play();
                    }
                    b = true;
                }
                
                if (isFirst)
                {
                    audioSource2.volume = Mathf.Clamp01((time - secondGate) / (speed - secondGate) * correctVolume);
                }
                else
                {
                    audioSource1.volume = Mathf.Clamp01((time - secondGate) / (speed - secondGate) * correctVolume);
                }
            }
            
            yield return null;  
        }

        float length;
        if (isFirst)
        {
            length = audioSource2.clip.length;
        }
        else
        {
            length = audioSource1.clip.length;
        }
        
        StartCoroutine(WaitingForSeconds(length - firstGate * 2));
        isFirst = !isFirst;
    }

    IEnumerator WaitingForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Change());
    }
}
