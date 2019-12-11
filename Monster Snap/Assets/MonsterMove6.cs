﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove6 : MonoBehaviour
{
    public GameObject player;

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
        if (player.GetComponent<RailMovement>().location == player.GetComponent<RailManager>().location6)
        {
            myAnim.Play("awaken");
        }
    }
}
