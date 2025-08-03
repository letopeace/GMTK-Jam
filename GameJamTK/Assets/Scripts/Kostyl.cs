using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kostyl : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Animator>().SetBool("IsWiping", true);
    }
}
