using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScroll : MonoBehaviour {

    public int mdelta;
    public float mspeed;
    private Vector3 direction = Vector3.up;
	// Use this for initialization
	void Start () {
        mdelta = 40;
        mspeed = 15;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 ruaScreen = Camera.main.WorldToScreenPoint(GameObject.Find("Rua").transform.position);
        

        if(Input.mousePosition.y > Screen.height - mdelta)
        {
            transform.position += direction * Time.deltaTime * mspeed;
        }
        if(Input.mousePosition.y < mdelta && ruaScreen.y < 0)
        {
            transform.position -= direction * Time.deltaTime * mspeed;
        }
    }
}
