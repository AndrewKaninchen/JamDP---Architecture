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
    //public Dictionary<Part, GameObject> partButtons;
    //private List<Part> availableParts;
    public List<GameObject> initiallyAvailablePartsPrefabs;



    private void Start()
    {
        foreach (var p in initiallyAvailablePartsPrefabs)
            AddPart(p);
    }

    public void AddPart(GameObject partPrefab)
    {
        var buttonInstance = Instantiate(partButtonPrefab, transform);
        buttonInstance.SetActive(true);
        var partButtonController = buttonInstance.GetComponent<PartButtonController>();
        partButtonController.PrepareButton(partPrefab.GetComponent<Part>(), this);
        //availableParts.Add();
    }

	//public void RemovePart(Part part)
 //   {
 //       //availableParts.Remove(part);
 //       //var button = partButtons[part];
 //       //partButtons.Remove(part);
 //       Destroy(button);
 //   }

    public void PreviewPart (Part partPrefab, GameObject button)
    {
        var instance = Instantiate(partPrefab.prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity, world.transform);
        var partInstance = instance.GetComponent<Part>();
        partInstance.enabled = false;
        partInstance.OnSpawn += () =>
        {
            //RemovePart(partInstance);
            Destroy(button);
        };
        instance.AddComponent<PartPreview>();
        
    }
}
