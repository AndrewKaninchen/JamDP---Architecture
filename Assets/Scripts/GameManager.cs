using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public System.Action OnToggleSimulating;
    public Canvas canvas;
    public GameObject boaPorra;
    public Toolbar toolbar;
    public GameObject world;
    public static GameManager Instance { get; private set; }

    private bool m_isSimulating;
    private bool hasWon = false;



    public bool IsSimulating 
    {
        get { return m_isSimulating; }
        set { Physics2D.autoSimulation = value; m_isSimulating = value; }
    }

    public void ToggleSimulation()
    {
        IsSimulating = !IsSimulating;
        OnToggleSimulating();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleSimulation();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    private void Start()
    {
        if (Instance)
            Destroy(Instance);
        Instance = this;
        toolbar.world = world;
        IsSimulating = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinDeGueime()
    {
        if (!hasWon)
        {
            var porra = Instantiate(boaPorra, canvas.transform);
            porra.SetActive(true);
            StartCoroutine(LoadMenu());
            hasWon = true;
        }
    }

    private IEnumerator LoadMenu ()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
