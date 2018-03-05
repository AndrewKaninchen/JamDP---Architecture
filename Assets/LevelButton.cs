using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int l;

    public void GoToLevel()
    {
        SceneManager.LoadScene(l);
    }
}
