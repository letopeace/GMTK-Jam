using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGame : MonoBehaviour
{
    public float right, left, top, bottom;
    public GameObject[] levels;
    public int currentIndex = 0;

    private void OnEnable()
    {
        RectTransform rt = GetComponent<RectTransform>();
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);
        
        right = corners[2].x;
        left = corners[0].x;
        top = corners[1].y;
        bottom = corners[0].y;
    }

    public void Launch()
    {
        gameObject.SetActive(true);
        levels[currentIndex].SetActive(true);
    }

    public void NextLevel()
    {
        levels[currentIndex].SetActive(false);
        
        currentIndex++;
        if (currentIndex >= levels.Length)
        {
            gameObject.SetActive(false);
            Camera.main.GetComponent<CameraController>().isFree = true;
            DialogueSystem.instance.player.isFree = true;
            GameManager.instance.array.SetActive(true);
        }
        else
        {
            levels[currentIndex].SetActive(true);
        }
    }
}
