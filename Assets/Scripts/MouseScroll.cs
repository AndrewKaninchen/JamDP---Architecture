using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScroll : MonoBehaviour {

    public int mdelta = 50;
    public float mspeed = 200.0f;
    private Vector3 direction = Vector3.up;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.mousePosition.y > Screen.height - mdelta)
        {
            transform.position += direction * Time.deltaTime * mspeed;
        }
        if(Input.mousePosition.y < mdelta && Input.mousePosition.y > 0)
        {
            transform.position -= direction * Time.deltaTime * mspeed;
        }
    }
}
