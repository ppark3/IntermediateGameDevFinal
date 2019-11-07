using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm; // the instance of the Game Manager

    public List<Texture2D> storedPhotos; // stores photos after a level ends so it can be scored etc.
    public List<int> storedPhotoNums; // stores the number of each photo we chose
    public int maxFilm;

    public HighScore playerScore; // player's name and score is stored in this class

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

        maxFilm = 50;
    }

    // Update is called once per frame
    void Update()
    {
    
    }


}

[System.Serializable]
public class HighScore
{
    public string _name;
    public int _num;
}

