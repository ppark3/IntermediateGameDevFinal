using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadesMonsterController : MonoBehaviour
{
    int currentDest;
    RailMovement rmove;
    RailManager rManage;
    public bool startPounce;
    public float speed;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rmove = FindObjectOfType<RailMovement>();
        rManage = FindObjectOfType<RailManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rmove.location == rManage.location17)
        {
            startPounce = true;
        }

        if (startPounce)
        {
            anim.Play("Armature|POUNCE");
            startPounce = false;
        }
    }
}
