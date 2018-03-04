using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartPreview : MonoBehaviour
{
    public SpriteRenderer sr;
    public Part part;
    public Rigidbody2D rb;
    public Collider2D col;

    private bool validPosition = true;

    public Color originalColor;
    private static Color previewColor = new Color(1f, 1f, 1f, .5f);
    private static Color invalidPositionColor = new Color(1f, 0f, 0f, .5f);


    void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        part = GetComponent<Part>();
        originalColor = sr.color;
        sr.color = previewColor;
        if (rb) rb.isKinematic = true;
        if (col) col.isTrigger = true;
    }

	void Update ()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3 (0f, 0f, 10f);
        
        if (validPosition && Input.GetMouseButtonDown(0))
        {
            part.enabled = true;
            Destroy(this);
            part.Spawn();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision);
        validPosition = false;
        sr.color = invalidPositionColor;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        validPosition = true;
        sr.color = previewColor;
    }

    private void OnDestroy()
    {
        sr.color = originalColor;
        if (rb) rb.isKinematic = false;
        if (col) col.isTrigger = false;
    }
}
