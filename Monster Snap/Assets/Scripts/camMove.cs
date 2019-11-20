using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour
{
    private GameObject mainCam;
    
    public float rotateSpeed;
    
    void Start()
    {
        mainCam = GameObject.FindWithTag("MainCamera");
        // sets camera to be straight at start
        mainCam.transform.rotation = Quaternion.identity;
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        // move camera up and down (with bounds so you can't turn all the way around)
        if (Input.GetKey(KeyCode.W) && ((mainCam.transform.eulerAngles.x > 290) || (mainCam.transform.eulerAngles.x <= 80f)))
        {
            mainCam.transform.rotation *= Quaternion.AngleAxis(rotateSpeed, Vector3.left);
        }
        else if (Input.GetKey(KeyCode.S) && ((mainCam.transform.eulerAngles.x >= 280) || (mainCam.transform.eulerAngles.x < 70f)))
        {
            mainCam.transform.rotation *= Quaternion.AngleAxis(rotateSpeed, Vector3.right);
        }

        // move cam left and right
        if (Input.GetKey(KeyCode.A))
        {
            mainCam.transform.rotation *= Quaternion.AngleAxis(rotateSpeed, Vector3.down);
            // mainCam.transform.RotateAround(mainCam.transform.position, Vector3.down, rotateSpeed);
        } else if (Input.GetKey(KeyCode.D))
        {
            mainCam.transform.rotation *= Quaternion.AngleAxis(rotateSpeed, Vector3.up);
            // mainCam.transform.RotateAround(mainCam.transform.position, Vector3.up, rotateSpeed);
        }
    }

    private void LateUpdate()
    {
        // lock z rotation
        mainCam.transform.rotation = Quaternion.Euler(mainCam.transform.eulerAngles.x, mainCam.transform.eulerAngles.y, 0);
    }
}
