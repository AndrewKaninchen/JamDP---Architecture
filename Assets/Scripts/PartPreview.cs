using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartPreview : MonoBehaviour
{
    public SpriteRenderer sr;
    public Part part;
    public Rigidbody2D rb;
    public Collider2D[] cols;

    private bool validPosition = true;
    private bool hasSpawned = false;

    public Color originalColor;
    private static Color previewColor = new Color(1f, 1f, 1f, .5f);
    private static Color invalidPositionColor = new Color(1f, 0f, 0f, .5f);


    void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        cols = GetComponents<Collider2D>();

        part = GetComponent<Part>();
        originalColor = sr.color;
        sr.color = previewColor;
        if (rb) rb.isKinematic = true;
        foreach (var col in cols)
            col.isTrigger = true; 
    }

	void Update ()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3 (0f, 0f, 10f);
        
        if (!hasSpawned && validPosition && Input.GetMouseButtonDown(0))
        {
            hasSpawned = true;
            part.enabled = true;
            part.Spawn();
            Destroy(this);
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
        foreach (var col in cols)
            col.isTrigger = false;
    }
}
