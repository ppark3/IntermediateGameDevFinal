using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm; // the instance of the Game Manager

    public List<Texture2D> storedPhotos; // stores photos after a level ends so it can be scored etc.
    public int maxFilm;

    // Start is called before the first frame update
    void Start()
    {
        if(gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gm);
        }
        else
        {
            Destroy(this);
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
