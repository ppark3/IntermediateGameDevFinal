using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailManager : MonoBehaviour
{

    public Transform location1;
    public Transform location2;

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
        if (other.gameObject.name == "Location1")
        {
            GetComponent<RailMovement>().location = location2;
        }
    }
}
