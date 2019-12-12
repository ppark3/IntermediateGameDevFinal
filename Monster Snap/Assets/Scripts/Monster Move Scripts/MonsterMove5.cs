using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove5 : MonoBehaviour
{
    public GameObject player;
    public bool startMove;
    public Transform destination1;
    public float speed;

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
        if (player.GetComponent<RailMovement>().location == player.GetComponent<RailManager>().location5)
        {
            startMove = true;
            myAnim.Play("run");
        }
        if (startMove)
        {
            PlaySounds ps = GetComponent<PlaySounds>();
            ps.PlaySFX(0);
            transform.position = Vector3.MoveTowards(transform.position, destination1.position, speed * Time.deltaTime); // moving towards the location!
            startMove = false;
        }
    }
}
