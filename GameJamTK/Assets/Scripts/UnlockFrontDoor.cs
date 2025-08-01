using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockFrontDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Barriers>().UnLockFront();
        }
    }
}
