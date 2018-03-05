using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMenuButtons : MonoBehaviour
{
    public GameObject template;
    public Sprite[] sprites;
    public int qtd;

    private void Start()
    {
        for (int i = 1; i < qtd; i++)
        {
            var b = Instantiate(template.gameObject, transform);
            b.SetActive(true);
            b.GetComponent<LevelButton>().l = i;
            b.GetComponent<Image>().sprite = sprites[i-1];
        }
    }
}
