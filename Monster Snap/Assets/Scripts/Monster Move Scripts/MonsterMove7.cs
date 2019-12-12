using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove7 : MonoBehaviour
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
        if (player.GetComponent<RailMovement>().location == player.GetComponent<RailManager>().location24)
        {
            PlaySounds ps = GetComponent<PlaySounds>();
            ps.PlaySFX(0);
            myAnim.Play("Rise");
        }
    }
}
