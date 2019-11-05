using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    private GameObject mainCam;
    private GameObject newCam;

    public float followSpeed;
    
    void Start()
    {
        newCam = GameObject.Find("Camera");
        mainCam = GameObject.Find("Main Camera");
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // follow mouse (doesn't work properly rn)
        
        /* if (newCam.activeSelf)
        {
            newCam.transform.LookAt(newCam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, newCam.GetComponent<Camera>().nearClipPlane)), Vector3.up);
        }
        else
        {
            mainCam.transform.LookAt(mainCam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, mainCam.GetComponent<Camera>().nearClipPlane)), Vector3.up);
        } */
    }
}
