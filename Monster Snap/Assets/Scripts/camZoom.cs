using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camZoom : MonoBehaviour
{
    private GameObject mainCam;
    private GameObject newCam;

    public KeyCode zoomKey;
    public float zoomDist;
    
    void Start()
    {
        newCam = GameObject.Find("Camera");
        mainCam = GameObject.Find("Main Camera");
        
        setMainCamActive();
    }
    
    void Update()
    {
        // cam switch
        if (Input.GetKeyDown(zoomKey))
        {
            setNewCamActive();
        } else if (Input.GetKeyUp(zoomKey))
        {
            setMainCamActive();
        }
    }

    private void FixedUpdate()
    {
        // zoom ??
    }

    void setMainCamActive()
    {
        mainCam.SetActive(true);
        newCam.SetActive(false);
    }

    void setNewCamActive()
    {
        mainCam.SetActive(false);
        newCam.SetActive(true);
    }
}
