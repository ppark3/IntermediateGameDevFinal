using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterManager : MonoBehaviour
{
    public static List<MonsterScript> monsters;
    public List<MonsterScript> m;

    private void Awake()
    {
        monsters = new List<MonsterScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (monsters.Count != m.Count)
        {
            m = new List<MonsterScript>();
            for (int i = 0; i < monsters.Count; i++)
            {
                m.Add(monsters[i]);
            }
        }
    }
}
