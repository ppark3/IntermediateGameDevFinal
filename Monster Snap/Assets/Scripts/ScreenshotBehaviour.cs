using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenshotBehaviour : MonoBehaviour // this script should be attached to a camera according to unity docs
{

    public KeyCode pictureButton;
    public List<Photo.PhotoInstance> screenshots; // list of textures that will be our screenshots

    public List<MonsterScript> monstersInPhoto; // temporary list that gets updated everytime screenshot is taken

    public GameObject imagePrefab; //prefab containg an image popup of ur photo!
    public Renderer renderer; // the renderer of the image showing the new screenshot!
    public Vector3 imageSpawnpos; // where is our new photo popping up?
    bool canTakePicture;

    // Updating Textbox-with-number-of-film-left variables
    public TextMeshProUGUI numberOfFilmLeft;

    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        screenshots = new List<Photo.PhotoInstance>(); //initializing list
        numberOfFilmLeft.text = "Film Left: " + (GameManager.gm.maxFilm - GameManager.gm.storedPhotos.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pictureButton) && !canTakePicture && camZoom.isZoomedIn)
        {
            canTakePicture = true;
        }
    }

    // " Will be called from camera after regular rendering is done. "
    private void OnPostRender()
    {
        if (canTakePicture && (GameManager.gm.storedPhotos.Count < GameManager.gm.maxFilm))
        {
            Photo.PhotoInstance newPhoto = new Photo.PhotoInstance();
            monstersInPhoto = new List<MonsterScript>();
            for (int i = 0; i < MonsterManager.monsters.Count; i++)
            {
                MonsterManager.monsters[i].isVisible();
                if (MonsterManager.monsters[i].isinCamera)
                {
                    MonsterManager.monsters[i].SetDistanceFromCamera();
                    MonsterManager.monsters[i].SetPositionFromCenter();

                    if(MonsterManager.monsters[i]._distance < 1000)
                    {
                        monstersInPhoto.Add(MonsterManager.monsters[i]);
                        newPhoto.monsters.Add(MonsterManager.monsters[i]);
                    }
                }
                else
                {
                    MonsterManager.monsters[i]._distance = 0;
                }
            }
            newPhoto.PickMainMonster();
            newPhoto.CalculateScore();

            Texture2D newTexture; // here's the new texture we're about to add to our list of screenshots
            newTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false); // getting screenshot by getting screen width/height and colord
            newTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false); // reading all the pictures on the screen to be stored for our screenshot
            newTexture.Apply(); // making sure that texture is UP TO DATE!
           
            newPhoto.photoImage = newTexture; // setting screenshot to the Photo object
            screenshots.Add(newPhoto); // adding photo to list of screenshots!
            GameManager.gm.storedPhotos.Add(newPhoto);

            numberOfFilmLeft.text = "Film Left: " + (GameManager.gm.maxFilm - GameManager.gm.storedPhotos.Count);

            ShowNewPhotoOnCanvas(newTexture); // show the picture!


            PlaySoundEffect pse = transform.parent.GetComponent<PlaySoundEffect>();
            pse.PlaySFX(2); // 0 is zoom in, 1 is zoom out, 2 is pic noise

            canTakePicture = false; // you can't take another one at the moment
        }
    }

    //function that makes the newest screenshot show up in the corner of the screen
    private void ShowNewPhotoOnCanvas(Texture2D newTexture)
    {
        img.gameObject.SetActive(true);
        //the below line creates a sprite out of the texture we have so it can be shown on a canvas
        img.sprite = Sprite.Create(newTexture, new Rect(0.0f, 0.0f, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.GetComponent<Animator>().Play(0); // plays the animation for the image to fade in and out

    }

    /*
    //function that creates a new gameobject to show what image we took and destroys it after 3 seconds
    private void ShowNewPhoto(Texture2D texture)
    {
        GameObject newPhoto = Instantiate(imagePrefab, transform);// show new photo
        renderer = newPhoto.GetComponent<Renderer>();// get new photos renderer
        renderer.material.mainTexture = texture; // make the new photo actually have the screenshot
        Destroy(newPhoto, 2f); //destroy photo after one second
    }*/
}
