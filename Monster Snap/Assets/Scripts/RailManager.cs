using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailManager : MonoBehaviour
{
    // the way movement works is it has a whole bunch of locations and constantly moves toward a new location every time it reaches its current one
    // it starts off by having its first location be set as location1
    // after the player reaches one location, it changes it the location variable in <RailMovement> to the next location in this script

    public Transform location1;
    public Transform location2;
    public Transform location3;
    public Transform location4;
    public Transform location5;
    public Transform location6;
    public Transform location7;
    public Transform location8;
    public Transform location9;
    public Transform location10;
    public Transform location11;
    public Transform location12;
    public Transform location13;
    public Transform location14;
    public Transform location15;
    public Transform location16;
    public Transform location17;
    public Transform location18;
    public Transform location19;
    public Transform location20;
    public Transform location21;
    public Transform location22;
    public Transform location23;
    public Transform location24;
    public Transform location25;

    public GameObject dragon;

    [Space] // making a space to see the waterfall particle system
    public GameObject waterSplash;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RailMovement>().location = location1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // when player reaches a location, it updates its new location
        // everything is just a repetition of this
        if (other.gameObject.GetInstanceID() == location1.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location2;
        }
        if (other.gameObject.GetInstanceID() == location2.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location3;
        }
        if (other.gameObject.GetInstanceID() == location3.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location4;
        }
        if (other.gameObject.GetInstanceID() == location4.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location5;
        }
        if (other.gameObject.GetInstanceID() == location5.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location6;
        }
        if (other.gameObject.GetInstanceID() == location6.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location7;
        }

        // this is the location right before the waterfall so we speed it up (to make it look like you're falling)
        if (other.gameObject.GetInstanceID() == location7.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location8;
            GetComponent<RailMovement>().speed = 15;
        }
        if (other.gameObject.GetInstanceID() == location8.gameObject.GetInstanceID())
        {
            Instantiate(waterSplash, transform.position, waterSplash.transform.rotation);
            // instantiate splash at where the player is with the particles rotation
            GetComponent<RailMovement>().location = location9;
            GetComponent<RailMovement>().speed = 5f;
        }

        // and then we return the speed to normal so that you're just "riding the trail car" again
        if (other.gameObject.GetInstanceID() == location9.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location10;
            GetComponent<RailMovement>().speed = 2.2f;
        }
        if (other.gameObject.GetInstanceID() == location10.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location11;
        }
        if (other.gameObject.GetInstanceID() == location11.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location12;
        }
        if (other.gameObject.GetInstanceID() == location12.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location13;
        }
        if (other.gameObject.GetInstanceID() == location13.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location14;
        }
        if (other.gameObject.GetInstanceID() == location14.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location15;
        }
        if (other.gameObject.GetInstanceID() == location15.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location16;
        }
        if (other.gameObject.GetInstanceID() == location16.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location17;
        }
        if (other.gameObject.GetInstanceID() == location17.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location18;
        }
        if (other.gameObject.GetInstanceID() == location18.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location19;
        }
        if (other.gameObject.GetInstanceID() == location19.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location20;
        }
        if (other.gameObject.GetInstanceID() == location20.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location21;
        }
        if (other.gameObject.GetInstanceID() == location21.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location22;
        }
        if (other.gameObject.GetInstanceID() == location22.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location23;
        }
        if (other.gameObject.GetInstanceID() == location23.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location24;
            dragon.gameObject.SetActive(true);
        }
        if (other.gameObject.GetInstanceID() == location24.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location25;
        }
    }
}
