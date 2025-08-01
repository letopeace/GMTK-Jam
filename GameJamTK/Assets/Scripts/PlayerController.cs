using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 5f;
    
	public Animator animator;
    
    
    private Transform playerSprite;
    private Vector3 startScale, invertedScale;
    private bool flip = false;

    private void Awake()
    {
        playerSprite = animator.transform;
        
        startScale = playerSprite.localScale;
        invertedScale = startScale;
        invertedScale.x = -startScale.x;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * speed;
        
        if (!DialogueSystem.instance.onWindow)
        {
            if (h > 0.02f || h < -0.02f)
            {
                rb2d.velocity = new Vector2(h, rb2d.velocity.y);
                animator.SetBool("walk", true);
                if (h > 0.02f && flip)
                {
                    flip = false;
                    playerSprite.localScale = startScale;
                }
                if (h < -0.02f && !flip)
                {
                    flip = true;
                    playerSprite.localScale = invertedScale;
                }
            }
            else
            {
                rb2d.velocity = Vector2.zero;
                animator.SetBool("walk", false);
            }
        }

        
    }
    
}
