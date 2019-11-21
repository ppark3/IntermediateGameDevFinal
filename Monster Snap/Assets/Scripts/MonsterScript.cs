using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script holding monster info
public class MonsterScript : MonoBehaviour
{
    Renderer renderer;
    public Camera mainCamera;
    public bool isinCamera;
    public float _distance;
    public float _position;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        renderer = GetComponent<Renderer>();
        MonsterManager.monsters.Add(this);
        isinCamera = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void isVisible() // if the creature is visible to a camera
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(this.transform.position);
        if ((viewPos.x < 1 && viewPos.x > 0 && viewPos.y < 1 && viewPos.y > 0) && viewPos.z > 0) // and if the creature is within the main camera...
        {
            isinCamera = true;
        }
        else
        {
            isinCamera = false;
        }
    }

    public void SetDistanceFromCamera() // Stores the distance between the monster and the camera
    {
        _distance = Vector3.Distance(this.transform.position, mainCamera.transform.position);
    }

    public void SetPositionFromCenter() // Stores the position of the creature within the camera's rectangle. Checks how far away it is from the center!
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(this.transform.position);
        float xposition = Mathf.Abs((viewPos.x) - (1 - viewPos.x));
        float yposition = Mathf.Abs((viewPos.y) - (1 - viewPos.y));
        _position = (xposition + yposition) / 2;
    }
}
