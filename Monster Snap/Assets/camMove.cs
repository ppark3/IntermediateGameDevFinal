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
        mainCam.transform.rotation = Quaternion.identity;
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        Debug.Log(mainCam.transform.localEulerAngles.x);
        if ((Input.GetKey(KeyCode.W) && mainCam.transform.eulerAngles.x > 290) || (Input.GetKey(KeyCode.W) && mainCam.transform.eulerAngles.x <= 0))
        {
            mainCam.transform.rotation *= Quaternion.AngleAxis(rotateSpeed, Vector3.left);
            // mainCam.transform.RotateAround(mainCam.transform.position, Vector3.left, moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))// && mainCam.transform.eulerAngles.x < 20f)
        {
            mainCam.transform.rotation *= Quaternion.AngleAxis(rotateSpeed, Vector3.right);
            // mainCam.transform.RotateAround(mainCam.transform.position, Vector3.right, rotateSpeed);
        }
        
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
        mainCam.transform.rotation = Quaternion.Euler(mainCam.transform.eulerAngles.x, mainCam.transform.eulerAngles.y, 0);
    }
}
