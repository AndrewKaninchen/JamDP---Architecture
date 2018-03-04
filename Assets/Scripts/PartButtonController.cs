using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartButtonController : MonoBehaviour
{
    public Image previewImage;
    public Button button;

    private void Start()
    {

    }

    public void PrepareButton (Part partPrefab, Toolbar toolbar)
    {
        previewImage.sprite = partPrefab.previewImage;
        button.onClick.AddListener(() => toolbar.PreviewPart(partPrefab, gameObject));
    }
}
