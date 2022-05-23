using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Canvas1;
    ARPlaneManager planeManager;
    ARRaycastManager raycastManager;
    ARPlane selectedPlane = null; 
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public delegate void PlaneSelectedEventHandler(ARPlane thePlane);
    public event PlaneSelectedEventHandler OnPlaneSelected;
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        planeManager = FindObjectOfType<ARPlaneManager>();
        planeManager.planesChanged += PlanesFound;
    }

    void Update()
    {
        if (Input.touchCount > 0 && planeManager.trackables.count > 0)
        {
            SelectPlane();
            Canvas1.SetActive(false);
        }
    }
    private void SelectPlane()
    {
         Touch touch = Input.GetTouch(0);
        

        if (touch.phase == TouchPhase.Began)
        {
            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                ARRaycastHit hit = hits[0];
                selectedPlane =  planeManager.GetPlane(hit.trackableId);
                // selectedPlane.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
                selectedPlane.GetComponent<MeshRenderer>().enabled = false;
                selectedPlane.GetComponent<LineRenderer>().positionCount = 0;
                selectedPlane.gameObject.layer = LayerMask.NameToLayer("Default");
                // selectedPlane.GetComponent<Renderer>().sortingOrder = 0;
                foreach(ARPlane plane in planeManager.trackables)
                {
                    if (plane != selectedPlane)
                    {
                        plane.gameObject.SetActive(false);
                    }
                }
                planeManager.enabled = false;
            }
        }
    }
    void PlanesFound(ARPlanesChangedEventArgs args)
    {
        if (selectedPlane == null && planeManager.trackables.count > 0)
        {
            planeManager.planesChanged -= PlanesFound;
        }
    }
}
