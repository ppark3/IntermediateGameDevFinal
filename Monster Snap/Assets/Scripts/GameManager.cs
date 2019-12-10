using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm; // the instance of the Game Manager

    public List<Photo.PhotoInstance> storedPhotos; // stores photos after a level ends so it can be scored etc.
    public List<int> storedPhotoNums; // stores the number of each photo we chose NO LONGER IN USE
    public List<Photo.PhotoInstance> ratedPhotos; // to be rated in rating scene

    public int maxFilm; // max amount of photos that can be taken

    public HighScore playerScore; // player's name and score is stored in this class

    public List<string> monstersInPhotos; //stores the names of the monsters in YOUR photos
    // the above list of string was made to be used in PhotoGallery manager

    // Start is called before the first frame update
    void Start()
    {
        ratedPhotos = new List<Photo.PhotoInstance>();
        storedPhotos = new List<Photo.PhotoInstance>();
        if(gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gm);
        }
        else
        {
            Destroy(this);
        }

        maxFilm = 30;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // This method turns a Texture 2D into a sprite. In goes a texture, out goes a sprite!
    public Sprite TurnTextureIntoSprite(Texture2D newTexture)
    {
        //The below line of code was taken from Unity's documentation
        Sprite s = Sprite.Create(newTexture, new Rect(0.0f, 0.0f, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        return s;
    }

}

[System.Serializable]
public class HighScore
{
    public string _name;
    public int _num;
}


    

