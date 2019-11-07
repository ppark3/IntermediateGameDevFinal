using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailManager : MonoBehaviour
{

    public Transform location1;
    public Transform location2;
    public Transform location3;
    public Transform location4;
    public Transform location5;
    public Transform location6;
    public Transform location7;
    public Transform location8;
    public Transform location9;

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

        // this is the location right before the waterfall
        if (other.gameObject.GetInstanceID() == location7.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location8;
            GetComponent<RailMovement>().speed = 10;
        }
        if (other.gameObject.GetInstanceID() == location8.gameObject.GetInstanceID())
        {
            GetComponent<RailMovement>().location = location9;
            GetComponent<RailMovement>().speed = 2;
        }
        if (other.gameObject.GetInstanceID() == location9.gameObject.GetInstanceID())
        {
            //GetComponent<RailMovement>().location = location2;
        }
    }
}
