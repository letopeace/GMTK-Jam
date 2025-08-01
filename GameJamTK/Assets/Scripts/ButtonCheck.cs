using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCheck : MonoBehaviour, IPointerDownHandler
{
    public bool checking = false;

    public BoardGame board;
    private float x = 0, y = 0;
    private Vector2 startPos;
    private Vector2 tempPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void OnEnable()
    {
        board = transform.parent.parent.GetComponent<BoardGame>();
    }

    private void Update()
    {
        if (checking)
        {
            Vector2 pos = startPos + ((Vector2)Input.mousePosition - tempPos);
            pos = new Vector2(Mathf.Clamp(pos.x, board.left, board.right), Mathf.Clamp(pos.y, board.bottom, board.top));

            transform.position = pos;
            
            if (Input.GetMouseButtonUp(0))
                checking = false;
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        tempPos = Input.mousePosition;
        startPos = transform.position;
        checking = true;
        //Debug.Log("checking");
    }
}
