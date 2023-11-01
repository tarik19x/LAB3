using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTrackingHandler : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager; // Reference to your ARTrackedImageManager
    [SerializeField] 
    public Text debuggInfo;
    void Update()
    {
        // Access the list of tracked images
        TrackableCollection<ARTrackedImage> trackedImages = trackedImageManager.trackables;

        // Iterate through the tracked images
        foreach (ARTrackedImage trackedImage in trackedImages)
        {
            // You can access the associated GameObject
            GameObject trackedImageObject = trackedImage.gameObject;
            debuggInfo.text = trackedImageObject.ToString();
        }
    }
}