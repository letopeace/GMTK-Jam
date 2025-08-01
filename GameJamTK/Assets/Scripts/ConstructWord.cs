using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConstructWord : MonoBehaviour
{
    public bool isDone = false;
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
        if (isDone)
            return;
        
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
                isDone = true;
                StartCoroutine(ConnectLetters());
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

    IEnumerator ConnectLetters()
    {
        float spacing = 70;
        float speed = 4f; // добавь свою скорость, если не задана

        Vector3 center = transform.parent.position;
        int count = letters.Count;
        Vector3[] positions = new Vector3[count];

        // Вычисление позиций по центру, с равным интервалом
        float startX = center.x - spacing * 0.5f * (count - 1);
        for (int i = 0; i < count; i++)
        {
            positions[i] = new Vector3(startX + i * spacing, center.y, letters[i].position.z);
        }

        // Двигаем каждую букву по отдельности
        for (int ind = 0; ind < count; ind++)
        {
            Vector3 startPos = letters[ind].position;
            Vector3 targetPos = positions[ind];
            float t = 0;

            while (t < 1f)
            {
                t += Time.deltaTime * speed;
                letters[ind].position = Vector3.Lerp(startPos, targetPos, t);
                yield return null;
            }

            letters[ind].position = targetPos; // фиксируем конечную позицию
        }

        yield return new WaitForSeconds(0.8f);
        transform.parent.GetComponent<BoardGame>().NextLevel();
    }
}
