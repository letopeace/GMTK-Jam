using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicArea : MonoBehaviour
{
    public MusicLogic music;
    public int index;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        music.Play(index);
    }
}
