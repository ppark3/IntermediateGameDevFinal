using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public Transform[] destinations;
    int currentDest;
    RailMovement rmove;
    RailManager rManage;
    public bool startMove;
    public float speed;

    public int whereToActivate; // which location will movement activate?
    // Start is called before the first frame update
    void Start()
    {
        rmove = FindObjectOfType<RailMovement>();
        rManage = FindObjectOfType<RailManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rmove.location == rManage.location8 && whereToActivate == 8)
        {
            startMove = true;
        }
        else if(rmove.location == rManage.location21 && whereToActivate == 21)
        {
            startMove = true;
        }
        else if (rmove.location == rManage.location13 && whereToActivate == 13)
        {
            startMove = true;
        }

        if (startMove)
        {
            if(transform.position != destinations[currentDest].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinations[currentDest].position, speed * Time.deltaTime); // moving towards the location!
            }
            else
            {
                if(destinations.Length > currentDest)
                {
                    currentDest++;
                }
            }
        }
    }
}
