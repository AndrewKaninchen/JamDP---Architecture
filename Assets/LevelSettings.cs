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
        //public float height;
        //public bool useHeight;
    }

    public List<InitiallyAvailablePart> initiallyAvailableParts;
    public WinCondition winCondition;
    public GameManager gameManager;

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
}
