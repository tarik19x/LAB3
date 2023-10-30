using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class ARRayActiveCast : MonoBehaviour
{
    [Tooltip("The anchor object to place at the hit point.")]
    public Transform raycastAnchor;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        if (raycastManager == null)
        {
            raycastManager = GetComponent<ARRaycastManager>();
        }
    }

    void Update()
    {
        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits))
        {
            foreach (ARRaycastHit hit in hits)
            {
                if (hit.trackable is ARPlane plane)
                {
                    raycastAnchor.position = hit.pose.position;
                    raycastAnchor.rotation = hit.pose.rotation;
                }
            }
        }
    }
}
