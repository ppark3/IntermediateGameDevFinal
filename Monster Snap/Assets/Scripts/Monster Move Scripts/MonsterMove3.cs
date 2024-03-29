﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove3 : MonoBehaviour
{
    public GameObject player;
    public bool startMove;
    public Transform destination1;
    public float speed;
    public bool running;

    public Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<RailMovement>().location == player.GetComponent<RailManager>().location3 && !running)
        {
            startMove = true;
            running = true;
            myAnim.Play("run");
        }
        if (startMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination1.position, speed * Time.deltaTime); // moving towards the location!
        }
        if (transform.position == destination1.position)
        {
            myAnim.Play("idle squirm");
        }
    }
}
