using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinArea : MonoBehaviour
{

    int contactCount = 0;
    float remainingTime;



    private void Update()
    {
        if (contactCount > 0)
        {

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
