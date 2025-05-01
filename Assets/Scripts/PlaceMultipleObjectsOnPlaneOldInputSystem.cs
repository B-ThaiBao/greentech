using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// This script allows placing multiple instances of a prefab on AR planes using the old Unity input system.
/// Attach it to a GameObject with an ARRaycastManager component.
/// </summary>
[RequireComponent(typeof(ARRaycastManager))]
public class PlaceMultipleObjectsOnPlaneOldInputSystem : MonoBehaviour {
    [Header("Prefab to Instantiate")]
    [Tooltip("Prefab will be instantiated at the touch location on detected AR planes.")]
    [SerializeField] private List<GameObject> modelsPrefab;

    private int currentIndex = -1;
    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    private void Awake() {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update() {
        // Skip if no touch detected
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        // Handle touch begin phase
        if (touch.phase == TouchPhase.Began && currentIndex != -1) {
            // Perform raycast against detected planes
            if (raycastManager.Raycast(touch.position, hitResults, TrackableType.PlaneWithinPolygon)) {
                Pose hitPose = hitResults[0].pose;
                spawnedObject = Instantiate(modelsPrefab[currentIndex], hitPose.position, hitPose.rotation);

                // Make the object face the camera
                Vector3 directionToCamera = Camera.main.transform.position - hitPose.position;
                directionToCamera.y = 0; // Optional: prevent tilting up/down
                spawnedObject.transform.rotation = Quaternion.LookRotation(directionToCamera);
            }
        }
    }

    public void OnClickChickenModel() {
        currentIndex = 0;
    }
    public void OnClickDeerModel() {
        currentIndex = 1;
    }
    public void OnClickDogModel() {
        currentIndex = 2;
    }
    public void OnClickHorseModel() {
        currentIndex = 3;
    }
    public void OnClickCatModel() {
        currentIndex = 4;
    }
    public void OnClickPinguinModel() {
        currentIndex = 5;
    }
    public void OnClickTigerModel() {
        currentIndex = 6;
    }
}
