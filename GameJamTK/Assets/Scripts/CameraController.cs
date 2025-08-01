using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float speed = 0.1f;
    public float leftBarrier = -10f;
    public float downBarrier = -5f;
    
    void LateUpdate()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y + 3.15f, transform.position.z);
        pos.x = Mathf.Max(pos.x, leftBarrier);
        pos.y = Mathf.Max(pos.y, downBarrier);
        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
    }
}
