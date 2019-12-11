using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove1 : MonoBehaviour
{
    public GameObject player;
    public bool startMove;
    public Transform destination1;
    public float speed;
    public float rotateSpeed;

    public Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rotateSpeed = 100f;

        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<RailMovement>().location == player.GetComponent<RailManager>().location2)
        {
            var q = Quaternion.LookRotation(destination1.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotateSpeed * Time.deltaTime);
            if (q == transform.rotation && !startMove)
            {
                myAnim.Play("fly");
                startMove = true;
            }
        }
        if (startMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination1.position, speed * Time.deltaTime); // moving towards the location!
        }
    }
}
