using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove4 : MonoBehaviour
{
    public GameObject player;
    public bool startMove;
    public bool startMove2;
    public float speed;
    public float rotateSpeed;

    public Transform location;
    public Transform location1;
    public Transform location2;

    public Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        location = location1;
        rotateSpeed = 100f;

        myAnim = GetComponent<Animator>();
        myAnim.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<RailMovement>().location == player.GetComponent<RailManager>().location5 && !startMove)
        {
            var q = Quaternion.LookRotation(location1.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotateSpeed * Time.deltaTime);
            if (q == transform.rotation && !startMove)
            {
                myAnim.Play("fly");
                startMove = true;
            }
        }

        if (startMove2)
        {
            var q = Quaternion.LookRotation(location.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotateSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, location.position, speed * Time.deltaTime); // moving towards the location!
        }
        else if (startMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, location.position, speed * Time.deltaTime); // moving towards the location!
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetInstanceID() == location1.gameObject.GetInstanceID())
        {
            location = location2;
            rotateSpeed = 300f;
            startMove2 = true;
        }
    }
}
