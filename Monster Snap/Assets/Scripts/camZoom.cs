﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camZoom : MonoBehaviour
{
    private Camera mainCam;
    public GameObject zoomUI;
    public GameObject filmLeft;

    public KeyCode zoomKey;

    // max zoom
    public float zoomFOV;
    public float normalFOV;

    public float zoomSpeed;

    public static bool isZoomedIn;

    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        mainCam.fieldOfView = normalFOV;
        zoomUI.SetActive(false);
        filmLeft.SetActive(true);
    }

    void Update()
    {
        if (isZoomedIn)
        {
            zoomUI.SetActive(true);
            filmLeft.SetActive(false);
        }
        else
        {
            zoomUI.SetActive(false);
            filmLeft.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        PlaySounds pse = GetComponent<PlaySounds>();


        if (Input.GetKeyDown(zoomKey) && mainCam.fieldOfView > zoomFOV)
        {
            pse.PlaySFX(0);
        }
        else if (Input.GetKeyUp(zoomKey) && mainCam.fieldOfView > zoomFOV)
        {
            pse.PlaySFX(1);
        }



        // adjust fov based on zoom speed to create a zoom in/ out effect
        if (Input.GetKey(zoomKey) && mainCam.fieldOfView > zoomFOV)
        {
            mainCam.fieldOfView = mainCam.fieldOfView - zoomSpeed;
            isZoomedIn = true;
        }
        else if (!Input.GetKey(zoomKey) && mainCam.fieldOfView < normalFOV)
        {
            mainCam.fieldOfView = mainCam.fieldOfView + zoomSpeed;
            isZoomedIn = false;
        }
    }
}