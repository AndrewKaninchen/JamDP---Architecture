using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CementBlock : Part
{
    List<Rigidbody2D> connected = new List<Rigidbody2D>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision);
        var otherRb = collision.rigidbody;
        var otherCementBlock = otherRb.GetComponent<CementBlock>();
        if (otherCementBlock != null)
        {
            if (otherCementBlock.connected.Contains(GetComponent<Rigidbody2D>()))
                return;
        }

        if (!connected.Contains(otherRb))
        {
            connected.Add(otherRb);
            var constraint = gameObject.AddComponent<FixedJoint2D>();
            constraint.connectedBody = otherRb;
        }
    }
}
