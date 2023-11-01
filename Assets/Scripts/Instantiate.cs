using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class Instantiate : MonoBehaviour
{
    [Tooltip("Transform whose position will be used to place the instantiated prefab. If not provided, will use camera forward.")]
    public Transform positionTransform;
    [Tooltip("The prefab to use to spawn objects.")]
    public GameObject prefab;
    public  ARRaycastManager raycastManager;
    private bool visibility;
    private bool visibility2;

    public Vector3 currentpose = Vector3.zero;
    public Text debuggInfo;
    public GameObject Tree;
    public GameObject Apple;
    [SerializeField] List<GameObject> instantiatedObjects = new List<GameObject>(); // Store instantiated objects and their states.
    [SerializeField] List<GameObject> instantiatedObjectsCopy = new List<GameObject>(); // Store instantiated objects and their states.
    [SerializeField] public Image imageToToggle;
    void Start()
    {
        visibility = false;
        visibility2 = false;
        if (raycastManager == null)
        {
            raycastManager = GetComponent<ARRaycastManager>();
        }
    }
    public void InstantiateObj()
    {
        Vector3 spawnPosition;
        Quaternion spawnRotation;

        if (positionTransform == null)
        {
            positionTransform = Camera.main.transform;
            spawnPosition = positionTransform.position + positionTransform.forward.normalized * 1f;
            spawnRotation = Quaternion.LookRotation(positionTransform.forward, positionTransform.up);
        }
        else
        {
            spawnPosition = positionTransform.position;
            spawnRotation = positionTransform.rotation;
        }

        GameObject go = Instantiate(prefab, spawnPosition, spawnRotation);

        if (go.GetComponent<ARAnchor>() == null)
        {
            go.AddComponent<ARAnchor>();
        }
    }
    
    
    

    public void InstantiateTreeAtCursor()
    {
        currentpose = ARRayActiveCast.currentRayPosition;
        Quaternion spawnRotation = positionTransform.rotation;

        GameObject go = Instantiate(Tree, currentpose, spawnRotation, transform);
        //go.gameObject.name = "Tree";
        if (go.GetComponent<ARAnchor>() == null)
        {
            go.AddComponent<ARAnchor>();
        }

        instantiatedObjects.Add(go); // Add the instantiated object to the list.
    }

    public void InstantiateAppleAtCursor()
    {
        currentpose = ARRayActiveCast.currentRayPosition;
        Quaternion spawnRotation = positionTransform.rotation;

        GameObject go = Instantiate(Apple, currentpose, spawnRotation, transform);
        //go.gameObject.name = "Apple";
        if (go.GetComponent<ARAnchor>() == null)
        {
            go.AddComponent<ARAnchor>();
        }

        instantiatedObjects.Add(go); // Add the instantiated object to the list.
    }

    

    
    
    
    public void InstantiateTreeInFrontOfCamera()
    {
        Vector3 spawnPosition;
        Quaternion spawnRotation;

        positionTransform = Camera.main.transform;
        spawnPosition = positionTransform.position + positionTransform.forward.normalized * 1f;
        spawnRotation = Quaternion.LookRotation(positionTransform.forward, positionTransform.up);
            
            
        GameObject go = Instantiate(Tree, spawnPosition, spawnRotation, transform);
        if (go.GetComponent<ARAnchor>() == null)
        {
            go.AddComponent<ARAnchor>();
        }
        instantiatedObjects.Add(go);
    }
    public void InstantiateAppleInFrontOfCamera()
    {
        Vector3 spawnPosition;
        Quaternion spawnRotation;

            positionTransform = Camera.main.transform;
            spawnPosition = positionTransform.position + positionTransform.forward.normalized * 1f;
            spawnRotation = Quaternion.LookRotation(positionTransform.forward, positionTransform.up);
            
            
        GameObject go = Instantiate(Apple, spawnPosition, spawnRotation, transform);

        if (go.GetComponent<ARAnchor>() == null)
        {
            go.AddComponent<ARAnchor>();
        }
        instantiatedObjects.Add(go);
    }
    
    public void ToggleObjAtCursor()
    {
        foreach (Transform child in transform)
        {
            //child.gameObject.SetActive(!child.gameObject.activeSelf);
            var objlist = child.gameObject.GetComponentsInChildren<Renderer>();
            
            foreach (var obj in objlist)
            {
                obj.gameObject.GetComponentInChildren<Renderer>().enabled = visibility;
            }
        }
        visibility = !visibility;
    }

    public void ToggleImages()
    {
        
        GameObject foundObject = GameObject.FindWithTag("TreeTrac");
        var objlist = foundObject.gameObject.GetComponentsInChildren<Renderer>();
            
        foreach (var obj in objlist)
        {
            obj.gameObject.GetComponentInChildren<Renderer>().enabled = visibility2;
        }

        visibility2 = !visibility2;
    }
    
    
    public void ToggleUserGuide()
    {
        bool isActive = imageToToggle.gameObject.activeSelf;

        // Toggle the visibility
        imageToToggle.gameObject.SetActive(!isActive);
        
    }
}
