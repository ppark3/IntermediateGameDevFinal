using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove1 : MonoBehaviour
{
    public GameObject player;
    public bool startMove;
    public Transform destination1;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<RailMovement>().location == player.GetComponent<RailManager>().location2)
        {
            startMove = true;
        }
        if (startMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination1.position, speed * Time.deltaTime); // moving towards the location!
        }
    }
}
