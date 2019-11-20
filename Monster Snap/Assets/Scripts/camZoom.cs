using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camZoom : MonoBehaviour
{
    private Camera mainCam;

    public KeyCode zoomKey;

    // max zoom
    public float zoomFOV;
    public float normalFOV;

    public float zoomSpeed;
    
    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        mainCam.fieldOfView = normalFOV;
    }
    
    void Update()
    {
    }

    private void FixedUpdate()
    {
        // adjust fov based on zoom speed to create a zoom in/ out effect
        if (Input.GetKey(zoomKey) && mainCam.fieldOfView > zoomFOV)
        {
            // zoom in
            mainCam.fieldOfView = mainCam.fieldOfView - zoomSpeed;
        } else if (!Input.GetKey(zoomKey) && mainCam.fieldOfView < normalFOV)
        {
            mainCam.fieldOfView = mainCam.fieldOfView + zoomSpeed;
        }
    }
}
