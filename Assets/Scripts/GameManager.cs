using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Toolbar toolbar;
    public GameObject world;
    public static GameManager Instance { get; private set; }

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
        if (Instance)
            Destroy(Instance);
        Instance = this;
        toolbar.world = world;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
