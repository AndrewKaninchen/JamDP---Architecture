using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Sprite pauseSprite;
    public Sprite playSprite;
    private Image img;

    private void Start()
    {
        img = GetComponent<Image>();
        GameManager.Instance.OnToggleSimulating += ChangeImage;
        ChangeImage();
    }
    public void ChangeImage ()
    {
        if (!GameManager.Instance.IsSimulating)
            img.sprite = playSprite;
        else
            img.sprite = pauseSprite;
    }
}
