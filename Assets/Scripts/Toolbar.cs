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

    private void Start()
    {
    }

    public void AddPart(GameObject partPrefab)
    {
        var buttonInstance = Instantiate(partButtonPrefab, transform);
        buttonInstance.SetActive(true);
        var partButtonController = buttonInstance.GetComponent<PartButtonController>();
        partButtonController.PrepareButton(partPrefab.GetComponent<Part>(), this);
    }
    
    public void PreviewPart (Part partPrefab, GameObject button)
    {
        var instance = Instantiate(partPrefab.prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity, world.transform);
        var partInstance = instance.GetComponent<Part>();
        partInstance.enabled = false;
        partInstance.OnSpawn += () =>
        {
            // Lidar com múltiplas instâncias do mesmo tipo
            Destroy(button);
        };
        instance.AddComponent<PartPreview>();
        
    }
}
