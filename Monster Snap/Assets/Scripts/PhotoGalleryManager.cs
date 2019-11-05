using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoGalleryManager : MonoBehaviour
{
    int currentPage; // each page shows four photos. Depending on the page it'll show different photos

    public Image[] shownPhotos;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.gm.storedPhotoNums = new List<int>();
        shownPhotos = GetComponentsInChildren<Image>();
        ShowPhotos();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void ShowPhotos()
    {
        for (int i = 0; i < shownPhotos.Length; i++)
        {
            if ((i + (currentPage * 4)) < GameManager.gm.storedPhotos.Count) //making sure we're not going out of bounds
            {
                // i + (currentPage * 4) bc we want to make it easy to show things in fours
                shownPhotos[i].sprite = TurnTextureIntoSprite(GameManager.gm.storedPhotos[i + (currentPage * 4)]);
                shownPhotos[i].GetComponent<PhotoBehaviour>().myPhotoNum = i + (currentPage * 4);

            }
        }
    }


    Sprite TurnTextureIntoSprite(Texture2D newTexture)
    {
        Sprite s =  Sprite.Create(newTexture, new Rect(0.0f, 0.0f, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        return s;
    }

    //function used if the player clicks the left arrow for the photos
    public void GoLeft()
    {
        currentPage++;
    }

    //function used if the player clicks the right arrow for photos
    public void GoRight()
    {
        currentPage--;
    }
   
}
