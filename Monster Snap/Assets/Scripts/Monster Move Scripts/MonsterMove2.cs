using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove2 : MonoBehaviour
{
    public Transform location;
    public float speed;
    public float rotateSpeed;

    public Animator myAnim;

    public Transform location1;
    public Transform location2;
    public Transform location3;
    public Transform location4;


    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 300f;

        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, location.position, speed * Time.deltaTime); // moving towards the location!
        var q = Quaternion.LookRotation(location.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetInstanceID() == location1.gameObject.GetInstanceID())
        {
            location = location2;
        }
        if (other.gameObject.GetInstanceID() == location2.gameObject.GetInstanceID())
        {
            location = location3;
        }
        if (other.gameObject.GetInstanceID() == location3.gameObject.GetInstanceID())
        {
            location = location4;
        }
        if (other.gameObject.GetInstanceID() == location4.gameObject.GetInstanceID())
        {
            location = location1;
        }
    }
}
