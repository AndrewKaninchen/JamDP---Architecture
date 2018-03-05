using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent (typeof (HorizontalLayoutGroup))]
public class Toolbar : MonoBehaviour
{
    public GameObject world;

    public GameObject partButtonPrefab;
    public HorizontalLayoutGroup horizontalLayoutGroup;
    
    private GameObject currentPreviewObject;

    private void Update()
    {
        if (currentPreviewObject != null && Input.GetMouseButtonDown(1))
        {
            Destroy(currentPreviewObject);
        }
    }

    public void AddPart(GameObject partPrefab)
    {
        var buttonInstance = Instantiate(partButtonPrefab, transform);
        buttonInstance.SetActive(true);
        var partButtonController = buttonInstance.GetComponent<PartButtonController>();
        partButtonController.PrepareButton(partPrefab.GetComponent<Part>(), this);
    }

    public void PreviewPart(Part partPrefab, GameObject button)
    {
        if (currentPreviewObject == null)
        {
            currentPreviewObject = Instantiate(partPrefab.prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity, world.transform);
            var partInstance = currentPreviewObject.GetComponent<Part>();
            partInstance.enabled = false;
            partInstance.OnSpawn += () =>
            {
                // Lidar com múltiplas instâncias do mesmo tipo
                Destroy(button);
                currentPreviewObject = null;
            };
            currentPreviewObject.AddComponent<PartPreview>();
        }
    }
}
