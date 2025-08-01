using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConstructWord : MonoBehaviour
{
    public string word;
    public float xPadding, yPadding;
    public bool inLine = false;
    
    public List<Transform> letters;
    public Transform[] sorted;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            letters.Add(transform.GetChild(i));
        }
    }

    private void Update()
    {
        Check();
        sorted = SortByPosition();
        
        if (inLine)
        {
            string wordInLine = "";
            for (int i = 0; i < sorted.Length; i++)
            {
                wordInLine += sorted[i].name;
            }

            if (wordInLine == word)
            {
                Debug.Log("DONE!!!");
            }
        }
    }

    private void Check()
    {
        Transform[] sorted = SortByPosition();
        
        float yDist;
        float xDist;

        for (int i = 0; i < sorted.Length - 1; i++)
        {
            xDist = sorted[i + 1].position.x - sorted[i].position.x;
            yDist = MathF.Abs(sorted[i + 1].position.y - sorted[i].position.y);

            if (!(xDist < xPadding && yDist < yPadding && xDist > 0))
            {
                inLine = false;
                return;
            }
        }
        
        inLine = true;
    }

    private Transform[] SortByPosition()
    {
        // Копируем все дочерние трансформы в список
        List<Transform> clone = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            clone.Add(transform.GetChild(i));
        }

        // Сортируем по позиции x (от меньшего к большему)
        clone.Sort((a, b) => a.position.x.CompareTo(b.position.x));

        // Возвращаем как массив
        return clone.ToArray();
    }
}
