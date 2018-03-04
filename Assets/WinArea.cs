using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinArea : MonoBehaviour
{
    private int contactCount = 0;
    private float remainingTime;
    private float requiredTime;
    private GameManager gm;


    public void Init (float requiredTime, GameManager gm)
    {
        this.gm = gm;
        this.requiredTime = requiredTime;
        remainingTime = requiredTime;
    }

    private void Update()
    {
        if (remainingTime <= 0)
            gm.WinDeGueime();
        else if (contactCount > 0)
        {
            remainingTime -= Time.deltaTime;
            print(remainingTime);
        }
        else
        {
            remainingTime = requiredTime;
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
