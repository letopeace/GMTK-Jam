using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour
{
    public GameObject backBarrier;
    public GameObject frontBarrier;

    private void OnEnable()
    {
        DialogueSystem.Spook += UnLockFront;
        backBarrier.GetComponent<Collider2D>().enabled = false;
    }

    private void OnDisable()
    {
        DialogueSystem.Spook -= UnLockFront;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        backBarrier.GetComponent<Collider2D>().enabled = true;
        DialogueSystem.instance.isSpoken = false;
    }

    public void UnLockFront()
    {
        frontBarrier.GetComponent<Collider2D>().enabled = false;
    }
}
