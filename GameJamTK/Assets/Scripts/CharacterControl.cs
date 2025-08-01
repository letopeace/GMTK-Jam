using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public CharacterType character;
    public GameObject firstPose; 
    public GameObject secondPose;

    private Animator rabbitAnimator;

    private void Start()
    {
        if (character == CharacterType.Rabbit)
        {
            rabbitAnimator = transform.GetChild(0).GetComponent<Animator>();
        }
    }

    public void Switch(bool isFirst = true)
    {
        if (character == CharacterType.Lucifer)
        {
            if (isFirst)
            {
                secondPose.SetActive(false);
                firstPose.SetActive(true);
            }
            else
            {
                secondPose.SetActive(true);
                firstPose.SetActive(false);
            }
        }
        else
        {
            if (isFirst)
            {
                rabbitAnimator.ResetTrigger("Jump");
                rabbitAnimator.SetTrigger("Roof");
                rabbitAnimator.SetBool("IsWiping", false);
            }
            else
            {
                rabbitAnimator.SetBool("IsWiping", true);
            }
        }
    }

    public void Jump()
    {
        if (character == CharacterType.Rabbit)
        {
            rabbitAnimator.ResetTrigger("Roof");
            rabbitAnimator.SetTrigger("Jump");
        }
    }
}
