using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    public Light light;
    public Color color;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        light.color = color;
    }
}
