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


    private float amountOfContacts;


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


        gameObject.layer = LayerMask.NameToLayer("PreviewPart");
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        amountOfContacts = 0;
        foreach (var c in cols)
        {
            ContactFilter2D filter = new ContactFilter2D();
            filter.SetLayerMask(LayerMask.GetMask("Default"));
            var res = new Collider2D[10];
            amountOfContacts += c.OverlapCollider(filter, res);
        }
        

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3 (0f, 0f, 10f);
        
        if (amountOfContacts > 0)
        {
            validPosition = false;
            sr.color = invalidPositionColor;
            return;
        }
        else
        {
            validPosition = true;
            sr.color = previewColor;
        }

        if (!hasSpawned && validPosition && Input.GetMouseButtonDown(0))
        {
            hasSpawned = true;
            part.enabled = true;
            part.Spawn();
            Destroy(this);
        }
	}

    private void OnDestroy()
    {
        sr.color = originalColor;
        if (rb) rb.isKinematic = false;
        foreach (var col in cols)
            col.isTrigger = false;

        gameObject.layer = LayerMask.NameToLayer("Default");
    }
}
