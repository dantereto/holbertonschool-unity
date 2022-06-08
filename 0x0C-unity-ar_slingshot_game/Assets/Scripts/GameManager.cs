using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameManager : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public ARRaycastManager arRaycastManager;
    public EnemyManager enemyManager;
    public UIManager uiManager;
    public ARPlane plane = null;
    private List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    private List<ARPlane> planes = new List<ARPlane>();
    private bool planeSelected = false;
    
    void Update()
    {
        if (planeSelected)
            return;

        if (Input.touchCount <= 0)
            return;

        Touch touch = Input.GetTouch(0);
        if (arRaycastManager.Raycast(touch.position, m_Hits))
        {
            ARRaycastHit hit = m_Hits[0];
            if ((hit.hitType & TrackableType.PlaneWithinPolygon) != 0)
            {
                plane = arPlaneManager.GetPlane(hit.trackableId);

                foreach (ARPlane onPlane in arPlaneManager.trackables)
                {
                    if (onPlane != plane)
                    {
                        onPlane.gameObject.SetActive(false);
                    }
                }

                planeSelected = true;
                LineRenderer lineRenderer = plane.gameObject.GetComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                lineRenderer.startColor = Color.red;
                lineRenderer.endColor = Color.red;
                arPlaneManager.enabled = false;
                uiManager.PlaneSelected(plane);
            }
        }
    }
}
