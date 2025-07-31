using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 5f;
    
    
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * speed;
        
        if (!DialogueSystem.instance.onWindow)
        {
            rb2d.velocity = new Vector2(h, rb2d.velocity.y);
        }
    }
    
}
