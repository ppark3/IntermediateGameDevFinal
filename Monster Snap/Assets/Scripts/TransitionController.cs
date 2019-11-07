using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    public Animator anim; // 0 fade black, 1 fade white, 2 screen in screen out

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }


    public void PlayTransiton(int num)
    {
        anim.SetInteger("whichAnim",num);
        anim.Play(0);
    }

}
