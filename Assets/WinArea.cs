using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinArea : MonoBehaviour
{
    public int contactCount = 0;
    public Color activeColor;
    public Color innactiveColor;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();    
    }

    private void Update()
    {
        if (contactCount > 0)
        {
            sr.color = innactiveColor;
        }
        else
        {
            sr.color = activeColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        contactCount++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        contactCount--;
    }
}
