using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Rope : MonoBehaviour
{
    public Transform root;
    public GameObject balloon;
    public GameObject pointTemplate;
    public float lenght;
    public int amountOfSegments;

    public LineRenderer lineRenderer;
    
    public GameObject[] points;

    private float segmentLenght;

    private void Start()
    {
        segmentLenght = lenght / amountOfSegments;

        points = new GameObject[amountOfSegments+1];
        points[0] = Instantiate(pointTemplate);
        points[0].SetActive(true);
        points[0].GetComponent<DistanceJoint2D>().connectedBody = root.GetComponent<Rigidbody2D>();

        for (int i = 1; i < amountOfSegments+1; i++)
        {
            points[i] = Instantiate(pointTemplate, root.position + new Vector3 (0f, segmentLenght*i, root.transform.position.z), Quaternion.identity);
            points[i].SetActive(true);
            var joint = points[i].GetComponent<DistanceJoint2D>();
            joint.connectedBody = points[i - 1].GetComponent<Rigidbody2D>();
            joint.distance = segmentLenght;

        }

        balloon.transform.position = root.position + new Vector3(0f, lenght, root.transform.position.z);
        balloon.GetComponent<FixedJoint2D>().connectedBody = points[amountOfSegments].GetComponent<Rigidbody2D>();

        lineRenderer.positionCount = amountOfSegments+1;
    }

    private void Update()
    {
        var query =
            from p in points
            select p.transform.position;

        lineRenderer.SetPositions(query.ToArray());
    }
}
