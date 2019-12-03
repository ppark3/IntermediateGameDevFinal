using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhotoGalleryManager : MonoBehaviour
{
    public int currentPage; // each page shows four photos. Depending on the page it'll show different photos

    public Image[] shownPhotos;

    public EventSystem es;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gm.storedPhotoNums = new List<int>();
        ShowPhotos();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    // This method allows for photos to be shown
    void ShowPhotos()
    {
        for (int i = 0; i < shownPhotos.Length; i++)
        {
            if ((i + (currentPage * 4)) < GameManager.gm.storedPhotos.Count) //making sure we're not going out of bounds. Only four photos shown at a time
            {
                shownPhotos[i].enabled = true;
                // i + (currentPage * 4) bc we want to make it easy to show things in fours
                shownPhotos[i].sprite = GameManager.gm.TurnTextureIntoSprite(GameManager.gm.storedPhotos[i + (currentPage * 4)].photoImage);
                shownPhotos[i].gameObject.GetComponent<PhotoBehaviour>().myPhotoNum = i + (currentPage * 4);

            }
            else
            {
                shownPhotos[i].enabled = false;
            }
        }
    }



    //function used if the player clicks the left arrow for the photos
    public void GoLeft()
    {
        if (currentPage > 0)
        {
            currentPage--;
            ShowPhotos();
        }
    }

    //function used if the player clicks the right arrow for photos
    public void GoRight()
    {
        if ((currentPage + 1) * 4 < GameManager.gm.storedPhotos.Count)
        {
            currentPage++;
            ShowPhotos();
        }
    }

    public void FinishGallery() // temp method allowing the player to skip over the naming scene and go straight to the rating scene
    {
        SceneController.sC.LoadScene("CreatureNameScene");
    }

}
