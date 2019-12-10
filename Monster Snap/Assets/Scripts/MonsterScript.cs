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
    public bool isDoingSpecialAction;

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

    public void isVisible()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(this.transform.position);
        if ((viewPos.x < 1 && viewPos.x > 0 && viewPos.y < 1 && viewPos.y > 0) && viewPos.z > 0) // checking to see if the monster is in the camera view
        {
            // now that we know if the monster is in the camera view, we need to draw a raycast from the monster to the player
            // we do this because we need to check if there is a gameobject between the player and monster blocking the player's view
            // if the raycast hits anything other than the player, we do not check the isinCamera variable
            Ray myRay = new Ray(this.transform.position, GameObject.Find("Player").transform.position - this.transform.position);
            Debug.DrawRay(this.transform.position, GameObject.Find("Player").transform.position - this.transform.position, Color.cyan, 100f);
            RaycastHit myHit = new RaycastHit(); 

            if (Physics.Raycast(myRay, out myHit, 10000f))
            {
                if (myHit.collider.tag == "Player")
                {
                    isinCamera = true;
                }
                else
                {
                    isinCamera = false;
                }
            }
            else
            {
                isinCamera = false;
            }
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
