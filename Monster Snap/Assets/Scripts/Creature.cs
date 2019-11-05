using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Creature",menuName ="Objects/Creatures",order = 0)]
public class Creature : ScriptableObject
{
    public string _name;
    public int points; // points for when you take a picture of the creature
    public GameObject prefab;
    public Animator anim;


    public void ChangeAnim(int num)
    {
        anim.SetInteger("whichAnim",num);
    }

}
