using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextScene : MonoBehaviour
{
    public float waitTime;
    public int sceneToLoad;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneController.sC.WaitThenLoad(sceneToLoad, waitTime);
        }
    }
}
