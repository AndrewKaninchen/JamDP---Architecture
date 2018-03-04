using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [System.Serializable]
    public struct InitiallyAvailablePart
    {
        public GameObject prefab;
        public int amount;
    }

    [System.Serializable]
    public struct WinCondition
    {
        public WinArea targetArea;
        public float timeRequired;
        public bool useMultipleTargetAreas;
        public WinArea[] targetAreas;
        //public float height;
        //public bool useHeight;
    }

    public List<InitiallyAvailablePart> initiallyAvailableParts;
    public WinCondition winCondition;
    public GameManager gameManager;

    private float remainingTime;


    private void Start()
    {
        foreach (var p in initiallyAvailableParts)
        { 
            for (int i = 0; i < p.amount; i++)
            {
                gameManager.toolbar.AddPart(p.prefab);
            }
        }
    }

    private void Update()
    {
        if (!winCondition.useMultipleTargetAreas)
        {
            if (winCondition.targetArea.contactCount > 0)
            {
                if (remainingTime <= 0)
                    GameManager.Instance.WinDeGueime();
                else
                {
                    remainingTime -= Time.deltaTime;
                    //print(remainingTime);
                }
            }
            else
            {
                remainingTime = winCondition.timeRequired;
            }

        }
        else
        {
            foreach (WinArea area in winCondition.targetAreas)
            {
                if (area.contactCount == 0)
                {
                    remainingTime = winCondition.timeRequired;
                    return;
                }
            }

            if (remainingTime <= 0)
                GameManager.Instance.WinDeGueime();
            else
            {
                remainingTime -= Time.deltaTime;
            }
        }
    }

    //private struct GraphComponent
    //{
    //    public GameObject parent;
    //    public List<GameObject> objects;
    //}
    //private List<GraphComponent> graphComponents;

    //private void FixedUpdate()
    //{
    //    var allParts = FindObjectsOfType<Part>();

    //    foreach (var part in allParts)
    //    {
    //        var cols = part.GetComponents<Collider2D>();
    //        foreach (var c in cols)
    //        {
    //             c.GetContacts()
    //            foreach ()
    //        }
    //        foreach (var component in graphComponents)
    //        {
    //            part.
    //            if (component.objects.Contains(part))
    //        }
    //    }
    //}
}
