using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMovement : MonoBehaviour
{
    // this script allows the player to constantly move towards its next target location

    public float speed; // how fast the player moves
    public Transform location; // the location the player moves towards

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, location.position, speed * Time.deltaTime); // moving towards the location!
    }
}
