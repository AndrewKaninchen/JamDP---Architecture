using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Part : MonoBehaviour
{
    public GameObject prefab;
    public Sprite previewImage;
    //public Collider2D spawnValidationCollider;
    private SpriteRenderer sr;

    public System.Action OnSpawn;

    public void Spawn ()
    {
        OnSpawn();
    }
}

public abstract class AttachablePart : MonoBehaviour
{
    public abstract void CheckSpawnValidation();
}
