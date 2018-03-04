using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public Transform root;
    public GameObject pointTemplate;
    public float lenght;
    public int amountOfSegments;
    
    public Transform[] points;

    private float segmentLenght;

    private void Start()
    {
        segmentLenght = lenght / amountOfSegments;



        for (int i = 0; i < amountOfSegments; i++)
        {

        }
    }

}
