using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Toolbar toolbar;
    public GameObject world;

    private bool m_isSimulating;
    public bool IsSimulating 
    {
        get { return m_isSimulating; }
        set { Physics2D.autoSimulation = value; m_isSimulating = value; }
    }

    public void ToggleSimulation()
    {
        IsSimulating = !IsSimulating;
    }

    private void Start()
    {
        toolbar.world = world;
    }



}
