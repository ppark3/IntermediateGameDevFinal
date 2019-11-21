using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterManager : MonoBehaviour
{
    public static List<MonsterScript> monsters; // static list of monsters so that creatures can be added to it and it's *consisitent*
    public List<MonsterScript> m; // viewable version of the static list

    private void Awake()
    {
        monsters = new List<MonsterScript>(); // initializing list
    }

    // Update is called once per frame
    void Update()
    {
        if (monsters.Count != m.Count) // if the two lists are different
        {
            m = new List<MonsterScript>(); // reset the viewable list
            for (int i = 0; i < monsters.Count; i++) // re-add things to the list
            {
                m.Add(monsters[i]);
            }
        }
    }
}
