using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove4 : MonoBehaviour
{
    public GameObject player;
    public bool startMove;
    public float speed;

    public Transform location;
    public Transform location1;
    public Transform location2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        location = location1;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<RailMovement>().location == player.GetComponent<RailManager>().location5)
        {
            startMove = true;
        }
        if (startMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, location.position, speed * Time.deltaTime); // moving towards the location!
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetInstanceID() == location1.gameObject.GetInstanceID())
        {
            location = location2;
        }
    }
}
