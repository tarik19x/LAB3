using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Instantiate : MonoBehaviour
{
    [Tooltip("Transform whose position will be used to place the instantiated prefab. If not provided, will use camera forward.")]
    public Transform positionTransform;
    [Tooltip("The prefab to use to spawn objects.")]
    public GameObject prefab;

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
}
